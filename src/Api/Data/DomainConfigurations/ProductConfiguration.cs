using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data.DomainConfigurations;

#pragma warning disable CS1591
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.Ignore(x => x.HasAvailableStocks);

        builder.Property(x => x.Title)
                .HasMaxLength(40)
                .IsRequired();

        builder.HasIndex(x => x.Title)
                .IsUnique();
    }
}