using DoeAqui.Domain.AggregateModels.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace DoeAqui.Infrastructure.Context
{
    public class DoeAquiContext : DbContext
    {
        public DoeAquiContext(DbContextOptions<DoeAquiContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}