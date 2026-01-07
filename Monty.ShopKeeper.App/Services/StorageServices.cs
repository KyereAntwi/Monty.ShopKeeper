using FluentResults;
using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Services;

public class StorageServices(IShopKeeperDbContext dbContext) : IStorageServices
{
    public async Task<Result> CreateStoragePlaceAsync(string title, int order, CancellationToken cancellationToken)
    {
        var existingStorage = await dbContext
            .StoragePlaces
            .Where(sp => sp.Title.ToLower() == sp.Title.ToLower())
            .FirstOrDefaultAsync(cancellationToken);

        if (existingStorage is not null)
            return Result.Fail("A storage place with the same title already exists.");

        var newStoragePlace = new StoragePlace
        {
            Title = title,
            Order = order
        };

        await dbContext.StoragePlaces.AddAsync(newStoragePlace, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Result.Ok();
    }

    public async Task<Result> DeleteStoargePlaceAsync(int storagePlaceId, CancellationToken cancellation = default)
    {
        var storage = await dbContext.StoragePlaces.FindAsync(storagePlaceId, cancellation);

        if (storage is null)
            return Result.Fail("Storage place not found.");

        dbContext.StoragePlaces.Remove(storage);
        await dbContext.SaveChangesAsync(cancellation);
        return Result.Ok();
    }

    public async Task<Result<IEnumerable<StoragePlace>>> GetAllStoragesAsync(CancellationToken cancellationToken = default)
    {
        var list = await dbContext
            .StoragePlaces
            .OrderByDescending(sp => sp.Order)
            .ToListAsync(cancellationToken);

        return list;
    }
}
