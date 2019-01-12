using System.Collections.Generic;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Messages;

namespace DoeAqui.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}