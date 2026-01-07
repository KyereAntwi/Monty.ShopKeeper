using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Services;
using Monty.ShopKeeper.App.Views;
using Monty.ShopKeeper.App.Views.Controls;

namespace Monty.ShopKeeper.App;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // DI registration
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) => 
            {
                config
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                var dbPath = Path.Combine(AppContext.BaseDirectory, "shopkeeper.db");
                string? connectionString = $"Data Source={dbPath}";
                services.AddDbContext<IShopKeeperDbContext, ShopKeeperDbContext>(options => options.UseSqlite(connectionString));

                services.AddScoped<IApplicationUserServices, ApplicationUserServices>();
                services.AddScoped<IStockServices, StockServices>();
                services.AddScoped<IStorageServices, StorageServices>();

                services.AddTransient<LoginFrm>();
                services.AddTransient<MainFrm>();
                services.AddTransient<AddProductFrm>();
                services.AddTransient<ProductListCtls>();
                services.AddTransient<StoragePlacesListCtls>();
                services.AddTransient<StockProductFrm>();
                services.AddTransient<CreateStorageFrm>();
                services.AddTransient<SalesHistoryCtls>();
                services.AddTransient<SalesCtls>();
            })
            .Build();

        // apply migrations at startup
        using (var scope = host.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShopKeeperDbContext>();
            dbContext.Database.Migrate();
        }

        var mainForm = host.Services.GetRequiredService<LoginFrm>();
        Application.Run(mainForm);
    }
}