using System;
using System.Linq;
using DoeAqui.Domain.AggregateModels.ProductAggregate;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DoeAqui.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DoeAquiContext context)
            : base(context) { }

        public Product GetByIdWithUser(Guid id)
        {
            return Context.Set<Product>().Include(p => p.User).FirstOrDefault(p => p.Id == id);
        }
    }
}