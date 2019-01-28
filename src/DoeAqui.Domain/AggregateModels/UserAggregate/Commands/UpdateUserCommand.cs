using System;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Commands
{
    public class UpdateUserCommand : BaseUserCommand
    {
        public UpdateUserCommand(Guid id, string name, string email, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}