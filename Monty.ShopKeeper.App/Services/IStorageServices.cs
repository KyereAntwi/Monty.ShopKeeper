using FluentResults;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Services;

public interface IStorageServices
{
    Task<Result> CreateStoragePlaceAsync(string title, int order, CancellationToken cancellation = default);
    Task<Result> DeleteStoargePlaceAsync(int storagePlaceId, CancellationToken cancellation = default);
    Task<Result<IEnumerable<StoragePlace>>> GetAllStoragesAsync(CancellationToken cancellationToken = default);
}
