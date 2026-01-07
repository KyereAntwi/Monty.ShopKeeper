using FluentResults;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Services;

public interface IApplicationUserServices
{
    Task<Result> AddUserAccountAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<Result> LoginAsync(string username, string password, CancellationToken cancellationToken = default);
    Task<Result> UpdatePasswordAsync(string username, string newPassword, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ApplicationUser>>> GetAllUsersAsync(CancellationToken cancellationToken = default);
    Task<Result<bool>> CheckIfAnyUserExistAsync(CancellationToken cancellationToken = default);
}
