using DoeAqui.Domain.Core.Events;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Events
{
    public class ProductEventHandler : IHandler<ProductCreatedEvent>
    {
        public void Handle(ProductCreatedEvent message)
        {
            // Send email and/or log
        }
    }
}