using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SimpleShop.src.Api.Domains;

namespace SimpleShop.src.Api.Data;
#pragma warning disable CS1591 
public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Order> Orders { get; set; } = default!;

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}