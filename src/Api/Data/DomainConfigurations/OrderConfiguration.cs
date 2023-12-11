using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data.DomainConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(x => x.Product)
                .WithMany(x => x.Orders);

        builder.HasOne(x => x.Buyer)
                .WithMany(x => x.Orders);
    }
}