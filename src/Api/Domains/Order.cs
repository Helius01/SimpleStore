namespace SimpleShop.src.Api.Domains;

public class Order : BaseEntity
{
    public int ProductId { get; set; }
    public DateTimeOffset CreationDate { get; private set; }
    public int BuyerId { get; set; }
    public Product Product { get; private set; } = null!;
    public User Buyer { get; private set; } = null!;
}