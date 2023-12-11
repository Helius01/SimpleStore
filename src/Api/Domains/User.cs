namespace SimpleShop.src.Api.Domains;

public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public IReadOnlyCollection<Order> Orders { get; private set; } = null!;
}