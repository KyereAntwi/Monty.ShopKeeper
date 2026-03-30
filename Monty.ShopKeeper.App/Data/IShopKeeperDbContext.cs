using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Data;

public interface IShopKeeperDbContext
{
    public DbSet<ApplicationUser> ApplicationUsers { get; }
    public DbSet<Product> Products { get; }
    public DbSet<Stock> Stocks { get; }
    public DbSet<Sale> Sales { get; }
    public DbSet<StoragePlace> StoragePlaces { get; }
    public DbSet<Basket> Baskets { get; }
    public DbSet<LoggedInUser> LoggedInUser { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
