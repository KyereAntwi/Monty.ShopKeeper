using FluentResults;
using Monty.ShopKeeper.App.Entities;
using Monty.ShopKeeper.App.Entities.Enums;

namespace Monty.ShopKeeper.App.Services;

public interface IApplicationUserServices
{
    Task<Result> AddUserAccountAsync(string username, string password, RoleType role, CancellationToken cancellationToken = default);
    Task<Result> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<Result> LogoutAsync(CancellationToken cancellationToken = default);
    Task<Result> UpdatePasswordAsync(string username, string currentPassword, string newPassword, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ApplicationUser>>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<Result<bool>> CheckIfAnyUserExistAsync(CancellationToken cancellationToken = default);
    Task<Result<ApplicationUser?>> GetUserAsync(string username, CancellationToken cancellationToken = default);
    Task<Result<LoggedInUser?>> GetLoggedInUserAsync(CancellationToken cancellationToken= default); 
}
