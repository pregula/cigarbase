using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarRatingsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok();
}