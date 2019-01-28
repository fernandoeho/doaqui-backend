using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Events
{
    public class UserEventHandler : IHandler<UserCreatedEvent>,
        IHandler<UserUpdatedEvent>
    {
        public void Handle(UserCreatedEvent message)
        {
            // Send email and/or log
        }

        public void Handle(UserUpdatedEvent message)
        {
            // Send email and/or log
        }
    }
}