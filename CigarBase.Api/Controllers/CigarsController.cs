using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarsController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
        => Ok();

    [HttpPost]
    public IActionResult Post()
        => Ok();

    [HttpPut("{cigarId:guid}")]
    public IActionResult Put(Guid cigarId)
        => Ok();

    [HttpDelete("{cigarId:guid}")]
    public IActionResult Delete(Guid cigarId)
        => Ok();
}