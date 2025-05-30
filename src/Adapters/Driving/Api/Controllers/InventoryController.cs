using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("InventoryController");
    }
}
