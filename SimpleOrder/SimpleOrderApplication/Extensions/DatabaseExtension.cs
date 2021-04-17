using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleOrder.Infra.Data;

namespace SimpleOrder.API.Extensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(configuration.GetConnectionString("MainDb"), options =>
            {
                options.MigrationsHistoryTable(DatabaseContext.MIGRATIONS_HISTORY_TABLE);

            }), ServiceLifetime.Scoped);            

            return services;
        }
    }
}
