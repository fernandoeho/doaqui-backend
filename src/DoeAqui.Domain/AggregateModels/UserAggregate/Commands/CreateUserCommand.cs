namespace DoeAqui.Domain.AggregateModels.UserAggregate.Commands
{
    public class CreateUserCommand : BaseUserCommand
    {
        public CreateUserCommand(string name, string email, string password, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Phone = phone;
        }
    }
}