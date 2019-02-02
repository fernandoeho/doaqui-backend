using DoeAqui.Application.Interfaces;
using DoeAqui.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DoeAqui.Api.Configurations
{
    public static class AppServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            return services;
        }
    }
}