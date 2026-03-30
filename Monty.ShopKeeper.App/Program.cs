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

        using IHost host = StartApp();

        var mainForm = host.Services.GetRequiredService<LoginFrm>();
        Application.Run(mainForm);
    }

    static IHost StartApp()
    {
        string _connectionString = string.Empty;
        IHost host = Host
            .CreateDefaultBuilder()
            .ConfigureAppConfiguration((context, config) =>
                    {
                        config
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables();
                    })
            .ConfigureServices((context, services) =>
                    {
                        var localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                        var company = "Monty";
                        var product = "ShopKeeperMS";
                        var dataFolder = Path.Combine(localAppData, company, product);

                        // ensure folder exists
                        Directory.CreateDirectory(dataFolder);

                        var dbPath = Path.Combine(dataFolder, "shopkeeper.db");
                        _connectionString = $"Data Source={dbPath};Cache=Shared";

                        var legacyDb = Path.Combine(AppContext.BaseDirectory, "shopkeeper.db");
                        if (File.Exists(legacyDb) && !File.Exists(dbPath))
                            File.Copy(legacyDb, dbPath);

                        services.AddDbContextPool<ShopKeeperDbContext>(options => options.UseSqlite(_connectionString));
                        services.AddScoped<IShopKeeperDbContext>(sp => sp.GetRequiredService<ShopKeeperDbContext>());

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
                        services.AddTransient<RegisterFrm>();
                        services.AddTransient<SystemUsersListCtls>();
                        services.AddTransient<ImportProductsFrm>();
                        services.AddTransient<PasswordResetFrm>();
                    })
            .Build();

        // apply migrations at startup
        using (var scope = host.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ShopKeeperDbContext>();
            dbContext.Database.Migrate();

            EnableWAL(_connectionString);
        }

        return host;
    }

    // enable WAL for better concurrency
    static void EnableWAL(string connectionString)
    {
        using var conn = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);
        conn.Open();
        using var cmd = conn.CreateCommand();
        cmd.CommandText = "PRAGMA journal_mode = WAL;";
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}