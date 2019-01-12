using System;
using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Events
{
    public abstract class BaseUserEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Phone { get; protected set; }
    }
}