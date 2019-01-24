using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Interfaces;
using DoeAqui.Infrastructure.Bus;
using DoeAqui.Infrastructure.Configuration;
using DoeAqui.Infrastructure.Context;
using DoeAqui.Infrastructure.Repositories;
using DoeAqui.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoeAqui.Api.Configurations
{
    public static class InfrastructureConfig
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IBus, InMemoryBus>();

            services.AddScoped<IUserRepository, UserRepository>();

            var databaseSettings = configuration.GetSection("Database").Get<DatabaseSettings>();
            services.AddDbContext<DoeAquiContext>(options => options.UseSqlServer(databaseSettings.ConnectionString));

            return services;
        }
    }
}