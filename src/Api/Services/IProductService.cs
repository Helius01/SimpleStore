using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Utils;

namespace SimpleShop.src.Api.Services;

/// <summary>
/// Provides functionalities on Product domain
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Returns product via given id if found.  
    /// </summary>
    /// <param name="id">Product Id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Either<string, Product>> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Returns the list of products
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IList<Product>> GetListAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new product and returns it.
    /// </summary>
    /// <param name="title">Product title</param>
    /// <param name="price">Product price</param>
    /// <param name="discount">Product discount</param>
    /// <param name="inventoryCount">Product inventory count</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Either<string, Product>> CreateAsync(string title, decimal price, int discount, int inventoryCount, CancellationToken cancellationToken);

    /// <summary>
    /// Increases the count of product's quantity
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="count">Count to increase</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Either<string, int>> IncreaseQuantity(int id, int count, CancellationToken cancellationToken);
}