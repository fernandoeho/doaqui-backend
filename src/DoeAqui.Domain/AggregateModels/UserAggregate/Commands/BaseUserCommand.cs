using System;
using DoeAqui.Domain.Core.Commands;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Commands
{
    public abstract class BaseUserCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Phone { get; protected set; }
    }
}