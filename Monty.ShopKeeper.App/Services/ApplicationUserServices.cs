
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Services;

public class ApplicationUserServices(IShopKeeperDbContext dbContext) : IApplicationUserServices
{
    public async Task<Result> AddUserAccountAsync(string username, string password, CancellationToken cancellationToken = default)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new ApplicationUser 
        {
            UserName = username,
            PasswordHash = hashedPassword
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
