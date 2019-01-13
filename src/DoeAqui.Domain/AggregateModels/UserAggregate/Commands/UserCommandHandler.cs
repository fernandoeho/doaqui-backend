using System;
using DoeAqui.Domain.AggregateModels.UserAggregate.Events;
using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.CommandHandlers;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Domain.Interfaces;
using DoeAqui.Helper;

namespace DoeAqui.Domain.AggregateModels.UserAggregate.Commands
{
    public class UserCommandHandler : CommandHandler,
        IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IBus _bus;

        public UserCommandHandler(IUserRepository userRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _userRepository = userRepository;
        }

        public void Handle(CreateUserCommand message)
        {
            if (_userRepository.GetByEmail(message.Email) != null)
            {
                _bus.SendEvent(new DomainNotification("Email", "Email já cadastrado"));
                return;
            }

            var passwordSalt = Cryptography.Salt();
            var passwordHash = Cryptography.Hash(message.Password, passwordSalt);

            var user = new User(Guid.NewGuid(), message.Name, message.Email, passwordHash, passwordSalt, message.Phone);

            if (!user.IsValid())
            {
                NotifyValidationErrors(user.ValidationResult);
                return;
            }

            _userRepository.Add(user);

            if (Commit())
                _bus.SendEvent(new UserCreatedEvent(user.Id, user.Name, user.Email, user.Password, user.Phone));
        }
    }
}