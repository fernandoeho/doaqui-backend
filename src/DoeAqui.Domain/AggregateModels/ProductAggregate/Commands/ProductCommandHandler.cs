using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Domain.CommandHandlers;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Domain.Interfaces;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Commands
{
    public class ProductCommandHandler : CommandHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }
    }
}