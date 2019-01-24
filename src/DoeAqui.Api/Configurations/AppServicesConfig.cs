using DoeAqui.Application.Interfaces;
using DoeAqui.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DoeAqui.Api.Configurations
{
    public static class AppServicesConfig
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();

            return services;
        }
    }
}