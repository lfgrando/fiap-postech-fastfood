using Microsoft.AspNetCore.Mvc;
using Order.Application.Services.DTOs;
using Order.Application.Services.Interfaces;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    #region Get

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(
        [FromQuery] int page,
        [FromQuery] int size,
        [FromQuery] string? status,
        CancellationToken cancellationToken)
    {
        var orderFilter = new OrderFilter(status, page, size);
        var orders = await _orderService.GetAllAsync(orderFilter, cancellationToken);

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        string id,
        CancellationToken cancellationToken)
    {
        var order = await _orderService.GetByIdAsync(id, cancellationToken);

        return Ok(order);
    }

    #endregion

    #region Post

    [HttpPost]
    public async Task<IActionResult> PostAsync(
        [FromBody] CreateRequest createRequest,
        CancellationToken cancellationToken)
    {
        var id = await _orderService.CreateAsync(
            createRequest,
            cancellationToken);

        return new CreatedResult("/order", id);
    }
    #endregion

    #region Patch

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatusAsync(
        [FromBody] UpdateStatusRequest updateRequest,
        string id,
        CancellationToken cancellationToken)
    {
        var updatedOrder = await _orderService.UpdateStatusAsync(
            id,
            updateRequest,
            cancellationToken);

        return Ok(updatedOrder);
    }

    #endregion

    #region Delete

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(
        string id,
        CancellationToken cancellationToken)
    {
        await _orderService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    #endregion
}