using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("StockController");
    }
}
