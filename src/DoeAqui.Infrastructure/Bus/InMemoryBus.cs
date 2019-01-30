using System;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Commands;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Messages;
using DoeAqui.Domain.Core.Notifications;
using Microsoft.AspNetCore.Http;

namespace DoeAqui.Infrastructure.Bus
{
    public class InMemoryBus : IBus
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceProvider _serviceProvider;

        public InMemoryBus(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _serviceProvider = httpContextAccessor.HttpContext.RequestServices;
        }

        public void SendCommand<T>(T command) where T : Command
        {
            Publish(command);
        }

        public void SendEvent<T>(T @event) where T : Event
        {
            Publish(@event);
        }

        private void Publish<T>(T message) where T : Message
        {
            if (_serviceProvider == null) return;

            var obj = _serviceProvider.GetService(message.MessageType.Equals("DomainNotification") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}