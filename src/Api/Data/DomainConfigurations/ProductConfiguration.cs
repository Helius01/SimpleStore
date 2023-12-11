using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data.DomainConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.Property(x => x.Title)
                .HasMaxLength(40)
                .IsRequired();

        builder.HasIndex(x => x.Title)
                .IsUnique();
    }
}