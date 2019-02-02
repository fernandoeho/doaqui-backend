using DoeAqui.Domain.AggregateModels.ProductAggregate;
using DoeAqui.Domain.AggregateModels.ProductAggregate.Repository;
using DoeAqui.Infrastructure.Context;

namespace DoeAqui.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DoeAquiContext context)
            : base(context) { }
    }
}