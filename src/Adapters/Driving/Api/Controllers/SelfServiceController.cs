using Microsoft.AspNetCore.Mvc;
using SelfService.Domain.Services.DTOs;
using SelfService.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SelfServiceController : ControllerBase
{
    private readonly IRegisterCustomerService _service;

    public SelfServiceController(IRegisterCustomerService service)
    {
        _service = service;
    }


    [HttpGet]
    [Route("customer/{cpf}")]
    public async Task<IActionResult> GetAsync([FromRoute] string cpf, CancellationToken cancellationToken)
    {
        var response = await _service.GetByCpfAsync(cpf, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    [Route("customer")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterCustomerRequest request, CancellationToken cancellationToken)
    {
        var response = await _service.RegisterAsync(request, cancellationToken);

        return Ok(response);
    }
}
