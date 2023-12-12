using Microsoft.AspNetCore.Mvc;
using SimpleShop.src.Api.Models;
using SimpleShop.src.Api.Services;

namespace SimpleShop.src.Api.Controllers;

/// <summary>
/// Provides rest api on Product resource
/// </summary>
[ApiController]
[Route("/api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="orderService"></param>
    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Creates a new order
    /// </summary>
    /// <param name="request">Request model</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
    {
        var createOrderResult = await _orderService.Create(buyerId: request.BuyerId, productId: request.ProductId, cancellationToken);

        return createOrderResult.Match<IActionResult>(
            left => BadRequest(new { message = left }),
            right => NoContent()
        );
    }
}