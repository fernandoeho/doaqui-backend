using DoeAqui.Domain.AggregateModels.ProductAggregate.Commands;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Events;
using DoeAqui.Domain.AggregateModels.UserAggregate.Commands;
using DoeAqui.Domain.AggregateModels.UserAggregate.Events;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace DoeAqui.Api.Configurations
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
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