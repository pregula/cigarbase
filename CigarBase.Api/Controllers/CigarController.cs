using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarController : ControllerBase
{
    public IActionResult Get()
        => Ok();
}