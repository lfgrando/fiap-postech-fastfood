using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class KitchenController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("KitchenController");
    }
}
