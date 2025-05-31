using Microsoft.AspNetCore.Mvc;
using Order.Application.Services.DTOs;
using Order.Application.Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("Order")]
public class PaymentController : ControllerBase
{
    private readonly IOrderService _orderService;

    public PaymentController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("{id}/checkout")]
    public async Task<IActionResult> CheckoutAsync(
        [FromBody] CheckoutRequest checkoutRequest,
        string id,
        CancellationToken cancellationToken)
    {
        var checkoutResponse = await _orderService.CheckoutAsync(id, checkoutRequest, cancellationToken);
        return Ok(checkoutResponse);
    }

    [HttpPost("{id}/confirm-payment")]
    public async Task<IActionResult> ConfirmPaymentAsync(
        string id,
        CancellationToken cancellationToken)
    {
        await _orderService.ConfirmPaymentAsync(id, cancellationToken);
        return NoContent();
    }
}
