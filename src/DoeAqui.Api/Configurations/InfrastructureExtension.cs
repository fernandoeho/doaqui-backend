using AutoMapper;
using DoeAqui.Application.AutoMapper;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Interfaces;
using DoeAqui.Infrastructure.Bus;
using DoeAqui.Infrastructure.Configuration;
using DoeAqui.Infrastructure.Context;
using DoeAqui.Infrastructure.Repositories;
using DoeAqui.Infrastructure.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoeAqui.Api.Configurations
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Infra
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBus, InMemoryBus>();

            var databaseSettings = configuration.GetSection("Database").Get<DatabaseSettings>();
            services.AddDbContext<DoeAquiContext>(options => options.UseSqlServer(databaseSettings.ConnectionString));

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // AutoMapper
            services.AddScoped<IMapper>(sp => new Mapper(AutoMapperConfiguration.RegisterMappingProfiles()));

            //.NET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}