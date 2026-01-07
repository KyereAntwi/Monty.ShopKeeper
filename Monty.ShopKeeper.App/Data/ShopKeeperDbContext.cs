using Microsoft.EntityFrameworkCore;
using Monty.ShopKeeper.App.Entities;

namespace Monty.ShopKeeper.App.Data;

public class ShopKeeperDbContext : DbContext, IShopKeeperDbContext
{
    public ShopKeeperDbContext(DbContextOptions<ShopKeeperDbContext> options) : base(options)
    {
        // remove default tracking behavior
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entity.State)
            {
                case EntityState.Added:
                    entity.Entity.CreatedAt = DateTime.UtcNow;
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entity.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Apply configurations from the current assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopKeeperDbContext).Assembly);
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Stock> Stocks => Set<Stock>();
    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<StoragePlace> StoragePlaces => Set<StoragePlace>();
    public DbSet<ProductStoragePlace> ProductStoragePlaces => Set<ProductStoragePlace>();
    public DbSet<Basket> Baskets => Set<Basket>();
}
