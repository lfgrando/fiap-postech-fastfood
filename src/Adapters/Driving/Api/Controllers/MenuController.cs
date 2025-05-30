using Menu.Domain.Services.DTOs;
using Menu.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _service;

    public MenuController(IMenuService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MenuItemResponse>>> GetAllAsync([FromQuery] MenuItemFilter filter, CancellationToken cancellationToken)
    {
        var menuItems = await _service.GetAllAsync(filter, cancellationToken);
        return Ok(menuItems);
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<MenuItemResponse>> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var menuItem = await _service.GetByIdAsync(id, cancellationToken);
        return Ok(menuItem);
    }

    [HttpPost]
    public async Task<ActionResult<MenuItemResponse>> RegisterAsync([FromBody] RegisterMenuItemRequest request, CancellationToken cancellationToken)
    {
        var menuItem = await _service.RegisterAsync(request, cancellationToken);
        return CreatedAtRoute("GetById", new { id = menuItem.Id }, menuItem);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(string id, [FromBody] UpdateMenuItemRequest request, CancellationToken cancellationToken)
    {
        await _service.UpdateAsync(id, request, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> SoftDeleteAsync(string id, CancellationToken cancellationToken)
    {
        await _service.SoftDeleteAsync(id, cancellationToken);
        return NoContent();
    }
}