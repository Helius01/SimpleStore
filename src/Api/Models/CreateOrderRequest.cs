namespace SimpleShop.src.Api.Models;

/// <summary>
/// The request model to create new order (buy)
/// </summary>
public class CreateOrderRequest
{
    /// <summary>
    /// Product Id
    /// </summary>
    /// <value></value>
    public int ProductId { get; set; }

    /// <summary>
    /// Buyer Id (User Id)
    /// </summary>
    /// <value></value>
    public int BuyerId { get; set; }
}