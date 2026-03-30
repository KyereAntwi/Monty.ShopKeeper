
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;

namespace Monty.ShopKeeper.App.Services;

public class ApplicationUserServices(IShopKeeperDbContext dbContext) : IApplicationUserServices
{
    public async Task<Result> AddUserAccountAsync(string username, string password, RoleType role, CancellationToken cancellationToken = default)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new ApplicationUser 
        {
            UserName = username,
            PasswordHash = hashedPassword,
            Role = role
        };

        await dbContext.ApplicationUsers.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result<bool>> CheckIfAnyUserExistAsync(CancellationToken cancellationToken = default)
    {
        return Result.Ok(await dbContext.ApplicationUsers.AnyAsync(cancellationToken));
    }

    public async Task<Result<IEnumerable<ApplicationUser>>> GetAllUsersAsync(CancellationToken cancellationToken = default)
    {
        var list = await dbContext.ApplicationUsers.ToArrayAsync(cancellationToken);
        return Result.Ok(list.AsEnumerable());
    }

    public async Task<Result<LoggedInUser?>> GetLoggedInUserAsync(CancellationToken cancellationToken = default)
     => await dbContext
        .LoggedInUser
        .Include(a => a.ApplicationUser)
        .AsSplitQuery()
        .FirstOrDefaultAsync(cancellationToken);

    public async Task<Result<ApplicationUser?>> GetUserAsync(string username, CancellationToken cancellationToken = default)
        => await dbContext.ApplicationUsers.FirstOrDefaultAsync(a => a.UserName == username, cancellationToken);

    public async Task<Result> LoginAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var existingUser = await dbContext
            .ApplicationUsers
            .Where(u => u.UserName == username)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser is null)
            return Result.Fail("Invalid credentials");

        var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, existingUser.PasswordHash);

        if (!isPasswordValid)
            return Result.Fail("Invalid credentails");

        // register in data access as the loggedin user
        if (await dbContext.LoggedInUser.AnyAsync(cancellationToken))
        {
            var loggedIn = await dbContext
                .LoggedInUser
                .AsTracking()
                .FirstAsync(cancellationToken);
            loggedIn.ApplicationUserId = existingUser.Id;
            dbContext.LoggedInUser.Update(loggedIn);
        } 
        else
        {
            await dbContext.LoggedInUser.AddAsync(new LoggedInUser { ApplicationUserId = existingUser.Id }, cancellationToken);
        }
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result> LogoutAsync(CancellationToken cancellationToken = default)
    {
        var all = await dbContext
            .LoggedInUser
            .AsTracking()
            .ToArrayAsync(cancellationToken);

        if (all.Length > 0)
        {
            dbContext.LoggedInUser.RemoveRange(all);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        return Result.Ok();
    }

    public async Task<Result> UpdatePasswordAsync(string username, string newPassword, CancellationToken cancellationToken = default)
    {
        var existingUser = await dbContext
            .ApplicationUsers
            .AsTracking()
            .Where(u => u.UserName == username)
            .FirstOrDefaultAsync(cancellationToken);

        if (existingUser is null)
            return Result.Fail("User not found");

        var newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

        existingUser.PasswordHash = newHashedPassword;
        dbContext.ApplicationUsers.Update(existingUser);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }
}
