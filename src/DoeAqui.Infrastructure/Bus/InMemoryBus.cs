using System;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Commands;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Messages;
using DoeAqui.Domain.Core.Notifications;

namespace DoeAqui.Infrastructure.Bus
{
    public class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        private static IServiceProvider Container => ContainerAccessor();

        public void SendCommand<T>(T command) where T : Command
        {
            Publish(command);
        }

        public void SendEvent<T>(T @event) where T : Event
        {
            Publish(@event);
        }

        private static void Publish<T>(T message) where T : Message
        {
            if (Container == null) return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}