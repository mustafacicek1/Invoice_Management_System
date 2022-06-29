using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalPrice).HasPrecision(8, 2);
            builder.Property(x => x.PaymentDate).HasColumnType("date");

            builder.HasOne(x => x.User)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Invoice)
                .WithMany(x => x.Payments)
                .HasForeignKey(x => x.InvoiceId);
        }
    }
}
