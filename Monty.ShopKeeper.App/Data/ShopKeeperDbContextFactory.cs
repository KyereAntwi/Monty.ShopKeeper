using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Monty.ShopKeeper.App.Data;

public class ShopKeeperDbContextFactory : IDesignTimeDbContextFactory<ShopKeeperDbContext>
{
    public ShopKeeperDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShopKeeperDbContext>();

        var dbPath = Path.Combine(AppContext.BaseDirectory, "shopkeeper.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");

        return new ShopKeeperDbContext(optionsBuilder.Options);
    }
}
