using Microsoft.Extensions.DependencyInjection;
using SimpleOrder.Application.Services;
using SimpleOrder.Application.Services.Interfaces;

namespace SimpleOrder.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserAppService, UserAppService>();

            return services;
        }
    }
}
