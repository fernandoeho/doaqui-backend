using AutoMapper;
using DoeAqui.Application.AutoMapper;
using DoeAqui.Application.Interfaces;
using DoeAqui.Application.Services;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Commands;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Events;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;
using DoeAqui.Domain.AggregateModels.UserAggregate.Events;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Notifications;
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

namespace DoeAqui.Infrastructure.IoC
{
    public static class ServicesInjector
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
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

            // Application Services
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();

            // Domain Notification
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Commands
            services.AddScoped<IHandler<CreateUserCommand>, UserCommandHandler>();
            services.AddScoped<IHandler<UpdateUserCommand>, UserCommandHandler>();

            services.AddScoped<IHandler<CreateProductCommand>, ProductCommandHandler>();

            // Events
            services.AddScoped<IHandler<UserCreatedEvent>, UserEventHandler>();
            services.AddScoped<IHandler<UserUpdatedEvent>, UserEventHandler>();

            services.AddScoped<IHandler<ProductCreatedEvent>, ProductEventHandler>();

            return services;
        }
    }
}