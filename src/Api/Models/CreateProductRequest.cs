namespace SimpleShop.src.Api.Models;
#pragma warning disable CS1591
/// <summary>
/// The request model to create a new product
/// </summary>
public class CreateProductRequest
{
    public string Title { get; set; } = null!;
    public decimal Price { get; set; }
    public int Discount { get; set; }
    public int InventoryCount { get; set; }
}