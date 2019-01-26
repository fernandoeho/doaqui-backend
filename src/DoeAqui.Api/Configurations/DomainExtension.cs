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

            // Events
            services.AddScoped<IHandler<UserCreatedEvent>, UserEventHandler>();
            return services;
        }
    }
}