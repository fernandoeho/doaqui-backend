using DoeAqui.Domain.AggregateModels.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoeAqui.Infrastructure.Mappings
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnType("integer")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.Size)
                .HasColumnType("varchar(25)")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.Freight)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Products);

            builder.Ignore(p => p.ValidationResult);

            builder.Ignore(p => p.CascadeMode);
        }
    }
}