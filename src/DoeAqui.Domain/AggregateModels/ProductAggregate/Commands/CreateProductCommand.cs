using System;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Enums;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Commands
{
    public class CreateProductCommand : BaseProductCommand
    {
        public CreateProductCommand(string title, string description, int quantity, string size, EStatus status, EFreight freight, string imageUrl, Guid userId)
        {
            Title = title;
            Description = description;
            Quantity = quantity;
            Size = size;
            Status = status;
            Freight = freight;
            ImageUrl = imageUrl;
            UserId = UserId;
        }
    }
}