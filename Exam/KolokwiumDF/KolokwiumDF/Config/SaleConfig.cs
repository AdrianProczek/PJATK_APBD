using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Config;


public class SaleConfig : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasKey(s => s.IdSale);
        builder.Property(s => s.IdSale).ValueGeneratedOnAdd();

        builder.Property(s => s.CreatedAt);

        builder.HasOne(s => s.Client)
            .WithMany(c => c.Sales)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Subscription)
            .WithMany(s => s.Sales)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
