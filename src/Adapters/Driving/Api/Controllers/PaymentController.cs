using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("PaymentController");
    }
}
