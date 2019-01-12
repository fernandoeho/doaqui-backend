using System;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Events
{
    public class UserCreatedEvent : BaseUserEvent
    {
        public UserCreatedEvent(Guid id, string name, string email, string password, string phone)
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