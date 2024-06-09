using KolokwiumDF.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace KolokwiumDF.Config;


public class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(s => s.IdSubscription);
        builder.Property(s => s.IdSubscription).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).HasMaxLength(100);

        builder.Property(s => s.RenewalPeriod);

        builder.Property(s => s.EndTime);

        builder.Property(s => s.Price);
    }
}

