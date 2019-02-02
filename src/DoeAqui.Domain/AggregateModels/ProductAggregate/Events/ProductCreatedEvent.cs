using System;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Enums;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Events
{
    public class ProductCreatedEvent : BaseProductEvent
    {
        public ProductCreatedEvent(Guid id, string title, string description, int quantity, string size, EStatus status, EFreight freight, string imageUrl)
        {
            Title = title;
            Description = description;
            Quantity = quantity;
            Size = size;
            Status = status;
            Freight = freight;
            ImageUrl = imageUrl;

            AggregateId = id;
        }
    }
}