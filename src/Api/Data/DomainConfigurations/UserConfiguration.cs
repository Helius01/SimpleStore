using Microsoft.EntityFrameworkCore;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data.DomainConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        
    }
}