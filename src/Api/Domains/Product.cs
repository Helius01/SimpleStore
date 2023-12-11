namespace SimpleShop.src.Api.Domains;

public class Product : BaseEntity
{
    public string Title { get; private set; } = null!;
    public int InventoryCount { get; private set; }
    public decimal Price { get; private set; }
    public int Discount { get; private set; }
    public IReadOnlyCollection<Order> Orders { get; private set; } = null!;
}