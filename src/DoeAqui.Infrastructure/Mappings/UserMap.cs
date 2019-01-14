using DoeAqui.Domain.AggregateModels.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoeAqui.Infrastructure.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(u => u.Password)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(u => u.PasswordSalt)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(u => u.Phone)
                .HasColumnType("varchar(25)")
                .IsRequired();

            builder.Ignore(u => u.ValidationResult);
            builder.Ignore(u => u.CascadeMode);
        }
    }
}