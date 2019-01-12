using DoeAqui.Domain.AggregateModels.UserAggregate.Repository;
using DoeAqui.Domain.CommandHandlers;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Domain.Interfaces;

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
            throw new System.NotImplementedException();
        }
    }
}