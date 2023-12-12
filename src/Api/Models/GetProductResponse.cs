namespace SimpleShop.src.Api.Models;

/// <summary>
/// The product response model
/// </summary>
public class GetProductResponse
{
    /// <summary>
    /// Product identifier
    /// </summary>
    /// <value></value>
    public int Id { get; set; }

    /// <summary>
    /// Product's title
    /// </summary>
    /// <value></value>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Product's price
    /// </summary>
    /// <value></value>
    public decimal Price { get; set; }

    /// <summary>
    /// Product's discount
    /// </summary>
    /// <value></value>
    public int Discount { get; set; }

    /// <summary>
    /// Product's inventory count
    /// </summary>
    /// <value></value>
    public int InventoryCount { get; set; }

    /// <summary>
    /// Product's net price
    /// </summary>
    /// <returns></returns>
    public decimal NetPrice => Price - (Price * Discount / 100);
}