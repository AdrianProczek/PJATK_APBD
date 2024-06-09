using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Config;

public class DiscountConfig : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(d => d.IdDiscount);
        builder.Property(d => d.IdDiscount).ValueGeneratedOnAdd();

        builder.Property(d => d.Value);

        builder.Property(d => d.DateFrom);

        builder.Property(d => d.DateTo);

        builder.HasOne(d => d.Subscription)
            .WithMany(s => s.Discounts)
            .HasForeignKey(d => d.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
