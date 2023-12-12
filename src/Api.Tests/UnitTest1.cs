using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Exceptions;
namespace Api.Tests;

public class UnitTest1
{

    [Theory]
    [InlineData(10)]
    [InlineData(29)]
    [InlineData(31)]
    [InlineData(100)]
    [InlineData(46)]
    [InlineData(73)]
    public void Product_Should_Create_With_Valid_Discount(int discountPercentage)
    {
        bool hasException = false;
        try
        {
            var product = new Product("test", 10, 10, discountPercentage);
        }
        catch (DomainException)
        {
            hasException = true;
        }

        Assert.False(hasException);
    }

    [Fact]
    public void Product_Inventory_Count_Should_Increase()
    {
        var product = new Product("Test", 10, 100, 0);

        product.IncreaseQuantity(5);

        Assert.Equal(15, product.InventoryCount);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("A long title of product which is new in amazon and people love it ")]
    public void Product_Should_Not_Create_With_Invalid_Titles(string title)
    {
        bool hasException = false;
        try
        {
            var product = new Product(title, 10, 10, 0);
        }
        catch (Exception ex)
        {
            if (ex is ArgumentNullException or DomainException)
                hasException = true;
        }

        Assert.True(hasException);
    }
}