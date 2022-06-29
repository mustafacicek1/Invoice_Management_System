using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mappings
{
    public class InvoiceMap : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Month).IsRequired().HasMaxLength(10);
            builder.Property(x => x.DuesPrice).HasPrecision(8, 2);
            builder.Property(x => x.InvoicePrice).HasPrecision(8, 2);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Invoices)
                .HasForeignKey(x => x.UserId);
        }
    }
}
