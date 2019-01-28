using System;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Events
{
    public class UserUpdatedEvent : BaseUserEvent
    {
        public UserUpdatedEvent(Guid id, string name, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;

            AggregateId = id;
        }
    }
}