namespace SimpleShop.src.Api.Domains;

#pragma warning disable CS1591
public class User : BaseEntity
{
    private User() { }

    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; private set; } = null!;
    public IReadOnlyCollection<Order> Orders { get; private set; } = null!;
}