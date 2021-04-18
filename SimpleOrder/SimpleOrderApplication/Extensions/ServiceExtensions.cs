using Microsoft.Extensions.DependencyInjection;
using SimpleOrder.Application.Services;
using SimpleOrder.Application.Services.Interfaces;
using SimpleOrder.Infra.Data.Repository;
using SimpleOrder.Infra.Data.Repository.Interface;

namespace SimpleOrder.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            return services;
        }

        public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
