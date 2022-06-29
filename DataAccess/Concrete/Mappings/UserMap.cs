using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
            builder.Property(x => x.IdentificationNumber).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(10);
            builder.Property(x => x.CarNumberPlate).HasMaxLength(10);
            builder.Property(x => x.Role).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(10);
        }
    }
}
