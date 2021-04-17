using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleOrder.Infra.Data;

namespace SimpleOrder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .MigrateGlobalContext()
                .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public static class IWebHostExtensions
    {
        public static IHost MigrateGlobalContext(this IHost webHost)
        {
            using var scope = webHost.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<DatabaseContext>>();
            var context = services.GetService<DatabaseContext>();

            try
            {
                logger.LogInformation("Migrating main database");

                context.Database.Migrate();

                logger.LogInformation("Main database successfully migrated");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error when migrating main database");
                throw;
            }

            return webHost;
        }
       
    }

}
