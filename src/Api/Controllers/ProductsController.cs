using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleShop.src.Api.Domains;
using SimpleShop.src.Api.Models;
using SimpleShop.src.Api.Services;

namespace SimpleShop.src.Api.Controllers;

/// <summary>
/// Provides rest api on Product resource
/// </summary>
[ApiController]
[Route("/api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="productService"></param>
    /// <param name="mapper"></param>
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    /// <summary>
    /// Returns the list of products
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<GetProductResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetList(CancellationToken cancellationToken)
    {
        var productList = await _productService.GetListAsync(cancellationToken);

        return Ok(productList.Select(x => _mapper.Map<GetProductResponse>(x)));
    }

    /// <summary>
    /// Returns a product via given id
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var getProductByIdResult = await _productService.GetByIdAsync(id, cancellationToken);

        if (getProductByIdResult.IsLeft)
            return BadRequest(new { message = getProductByIdResult.LeftOrDefault() });

        var product = getProductByIdResult.RightOrDefault();

        return Ok(_mapper.Map<GetProductResponse>(product));
    }

    /// <summary>
    /// Creates and returns a new product
    /// </summary>
    /// <param name="request">Request model which carry required params</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var createProductResult = await _productService.CreateAsync(
            request.Title,
            request.Price,
            request.Discount,
            request.InventoryCount
            , cancellationToken);

        if (createProductResult.IsLeft)
            return BadRequest(new { message = createProductResult.LeftOrDefault() });


        return Created("/api/[controller]/{id}", createProductResult.RightOrDefault()!.Id);
    }

    /// <summary>
    /// Increases the quantity of the product
    /// </summary>
    /// <param name="id">Product id</param>
    /// <param name="count">Count to increase</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}/Quantity")]
    public async Task<IActionResult> IncreaseQuantity([FromRoute] int id, [FromBody] int count, CancellationToken cancellationToken)
    {
        var increaseQuantityResult = await _productService.IncreaseQuantity(id, count, cancellationToken);

        return increaseQuantityResult.Match<IActionResult>(
            left => BadRequest(new { message = left }),
            right => Ok(new { newQuantity = right })
        );
    }

}