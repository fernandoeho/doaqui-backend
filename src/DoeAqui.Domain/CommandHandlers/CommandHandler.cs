using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Domain.Interfaces;
using FluentValidation.Results;

namespace DoeAqui.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;
        private readonly IBus _bus;
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotifyValidationErrors(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _bus.SendEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            if (_uow.Commit())
                return true;

            _bus.SendEvent(new DomainNotification("Commit", "Error while saving data into database"));
            return false;
        }
    }
}