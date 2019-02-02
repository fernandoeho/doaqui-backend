using System;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Events;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Domain.CommandHandlers;
using DoeAqui.Domain.Core.Bus;
using DoeAqui.Domain.Core.Events;
using DoeAqui.Domain.Core.Notifications;
using DoeAqui.Domain.Interfaces;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Commands
{
    public class ProductCommandHandler : CommandHandler,
        IHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IBus _bus;

        public ProductCommandHandler(IProductRepository productRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public void Handle(CreateProductCommand message)
        {
            var product = new Product(Guid.NewGuid(), message.Title, message.Description, message.Quantity, message.Size, message.Status, message.Freight, message.ImageUrl);

            if (!product.IsValid())
            {
                NotifyValidationErrors(product.ValidationResult);
                return;
            }

            _productRepository.Add(product);

            if (Commit())
                _bus.SendEvent(new ProductCreatedEvent(product.Id, product.Title, product.Description, product.Quantity, product.Size, product.Status, product.Freight, product.ImageUrl));
        }
    }
}