using Microsoft.EntityFrameworkCore;
using SimpleShop.src.Api.Data;
using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Utils;

namespace SimpleShop.src.Api.Services;

/// <summary>
/// The first implementation of IOrderService which gives you some functions to manage Order 
/// </summary>
public class OrderService : IOrderService
{
    private readonly DataContext _context;

    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="context"></param>
    public OrderService(DataContext context)
    {
        _context = context;
    }

    ///<inheritdoc />
    public async Task<Either<string, Order>> Create(int buyerId, int productId, CancellationToken cancellationToken)
    {
        var buyer = await _context.Users.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == buyerId, cancellationToken);

        if (buyer is null)
            return Either<string, Order>.Left($"Couldn't find buyer with id = ({buyerId})");

        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);

        if (product is null)
            return Either<string, Order>.Left($"Couldn't find product with id = ({buyerId})");

        if (!product.HasAvailableStocks)
            return Either<string, Order>.Left($"The product with id = ({buyerId}) is out of stock");

        var newOrder = new Order(productId: productId, buyerId: buyerId);

        product.DecreaseQuantity(1);

        _context.Products.Update(product);
        _context.Orders.Add(newOrder);

        await _context.SaveChangesAsync(cancellationToken);

        return Either<string, Order>.Right(newOrder);
    }
}