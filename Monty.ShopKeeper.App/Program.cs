using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monty.ShopKeeper.App.Data;
using Monty.ShopKeeper.App.Views;

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
                IConfiguration configuration = context.Configuration;

                string? connectionString = configuration.GetConnectionString("ShopKeeperDatabase");
                services.AddDbContext<IShopKeeperDbContext, ShopKeeperDbContext>(options => options.UseSqlite(connectionString));

                // Register other services and forms
                services.AddTransient<LoginFrm>();
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