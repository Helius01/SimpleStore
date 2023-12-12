using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Utils;

namespace SimpleShop.src.Api.Services;

/// <summary>
/// Provides functionalities on Order domain
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Creates and returns a new order
    /// </summary>
    /// <param name="buyerId">Buyer id</param>
    /// <param name="productId">Product id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Either<string, Order>> Create(int buyerId, int productId, CancellationToken cancellationToken);
}