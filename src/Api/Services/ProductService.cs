using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SimpleShop.src.Api.Data;
using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Utils;

namespace SimpleShop.src.Api.Services;

/// <summary>
/// The first implementation of IProductService which gives you some functions to manage Product 
/// </summary>
public class ProductService : IProductService
{
    private readonly DataContext _context;
    private readonly IMemoryCache _memoryCache;

    //CacheKey
    private const string PRODUCT_LIST_CACHE_KEY = "PRODUCT_LIST";

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="context"></param>
    /// <param name="memoryCache"></param>
    public ProductService(DataContext context, IMemoryCache memoryCache)
    {
        _context = context;
        _memoryCache = memoryCache;
    }

    ///<inheritdoc />
    public async Task<Either<string, Product>> CreateAsync(string title, decimal price, int discount, int inventoryCount, CancellationToken cancellationToken)
    {
        var isDuplicateTitle = await _context.Products.AnyAsync(x => x.Title == title, cancellationToken);

        if (isDuplicateTitle)
            return Either<string, Product>.Left("Product's title is duplicate");

        var product = new Product(title, inventoryCount, price, discount);

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        await UpdateListInCacheAsync(cancellationToken);

        return Either<string, Product>.Right(product);
    }

    ///<inheritdoc />
    public async Task<Either<string, Product>> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var cachedValueList = _memoryCache.Get<List<Product>>(PRODUCT_LIST_CACHE_KEY);

        var productInCache = cachedValueList?.SingleOrDefault(x => x.Id == id);

        if (productInCache is not null)
            return Either<string, Product>.Right(productInCache);

        var product = await _context.Products.AsNoTracking()
                                                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (product is null)
            return Either<string, Product>.Left($"Couldn't find product with id = ({id})");

        await UpdateListInCacheAsync(cancellationToken);

        return Either<string, Product>.Right(product);
    }

    ///<inheritdoc />
    public async Task<IList<Product>> GetListAsync(CancellationToken cancellationToken)
    {
        var cachedValue = _memoryCache.Get<List<Product>>(PRODUCT_LIST_CACHE_KEY);

        if (cachedValue is not null)
            return cachedValue;

        var productList = await _context.Products.AsNoTracking()
                                                .ToListAsync(cancellationToken);

        await UpdateListInCacheAsync(cancellationToken);

        return productList;
    }

    ///<inheritdoc />
    public async Task<Either<string, int>> IncreaseQuantity(int id, int count, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (product is null)
            return Either<string, int>.Left($"Couldn't find product with id = ({id})");

        product.IncreaseQuantity(count);

        _context.Products.Update(product);
        await _context.SaveChangesAsync(cancellationToken);

        await UpdateListInCacheAsync(cancellationToken);

        return Either<string, int>.Right(product.InventoryCount);

    }

    /// <summary>
    /// Gets the list of products from db then stores in cache
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task UpdateListInCacheAsync(CancellationToken cancellationToken)
    {
        var productList = await _context.Products.ToListAsync(cancellationToken);

        _memoryCache.Set(PRODUCT_LIST_CACHE_KEY, productList);
    }
}