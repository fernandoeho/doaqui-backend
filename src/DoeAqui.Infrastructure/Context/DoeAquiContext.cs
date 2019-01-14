using DoeAqui.Domain.AggregateModels.UserAggregate;
using DoeAqui.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DoeAqui.Infrastructure.Context
{
    public class DoeAquiContext : DbContext
    {
        public DoeAquiContext(DbContextOptions<DoeAquiContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserMap(modelBuilder.Entity<User>());
        }
    }
}