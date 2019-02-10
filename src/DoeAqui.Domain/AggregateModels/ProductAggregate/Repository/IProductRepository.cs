using System;
using DoeAqui.Domain.Interfaces;

namespace DoeAqui.Domain.AggregateModels.ProductAggregate.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetByIdWithUser(Guid id);
    }
}