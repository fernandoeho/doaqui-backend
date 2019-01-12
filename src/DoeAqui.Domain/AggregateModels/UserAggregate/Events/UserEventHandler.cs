using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Events
{
    public class UserEventHandler : IHandler<UserCreatedEvent>
    {
        public void Handle(UserCreatedEvent message)
        {
            // Send email and/or log
        }
    }
}