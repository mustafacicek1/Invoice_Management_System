using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mappings
{
    public class ApartmentMap : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type).IsRequired().HasMaxLength(3);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Apartments)
                .HasForeignKey(x => x.UserId);
        }
    }
}
