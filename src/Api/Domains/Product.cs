using SimpleShop.src.Api.Exceptions;
namespace SimpleShop.src.Api.Domains;

#pragma warning disable CS1591
public class Product : BaseEntity
{
    private Product() { }

    public Product(string title, int inventoryCount, decimal price, int discount)
    {
        //Title validation
        ArgumentNullException.ThrowIfNull(title);
        if (title.Length > 40)
            throw new DomainException("Product's title must be less than 40 character");

        //Discount validation
        if (discount > 100)
            throw new DomainException("Product's discount must be less than 100");

        //Price validation
        if (price < 1)
            throw new DomainException("Product's price must be grater than the 1");

        if (inventoryCount < 1)
            throw new DomainException("Product's quantity must be grater than the 1");

        Title = title;
        InventoryCount = inventoryCount;
        Price = price;
        Discount = discount;
    }

    public string Title { get; private set; } = null!;
    public int InventoryCount { get; private set; }
    public decimal Price { get; private set; }
    public int Discount { get; private set; }
    public bool HasAvailableStocks => InventoryCount > 0;
    public IReadOnlyCollection<Order> Orders { get; private set; } = null!;

    /// <summary>
    /// Increase quantity
    /// </summary>
    /// <param name="count"></param>
    public void IncreaseQuantity(int count)
    {
        InventoryCount += count;
    }

    /// <summary>
    /// Decrease quantity
    /// </summary>
    /// <param name="count"></param>
    public void DecreaseQuantity(int count)
    {
        if (InventoryCount - count < 0)
            throw new DomainException($"Not enough quantity for product with id = ({Id})");

        InventoryCount -= count;
    }
}