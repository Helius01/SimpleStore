namespace SimpleShop.src.Api.Domains;

#pragma warning disable CS1591 
public class Order : BaseEntity
{
    /// <summary>
    /// FOR EF
    /// </summary>
    private Order() { }

    public Order(int productId, int buyerId)
    {
        ProductId = productId;
        BuyerId = buyerId;
        CreationDate = DateTimeOffset.UtcNow;
    }

    public int ProductId { get; private set; }
    public DateTimeOffset CreationDate { get; private set; }
    public int BuyerId { get; set; }
    public Product Product { get; private set; } = null!;
    public User Buyer { get; private set; } = null!;
}