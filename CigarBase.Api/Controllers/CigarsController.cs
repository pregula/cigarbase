using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarsController : ControllerBase
{
    private IQueryHandler<GetCigars, IEnumerable<CigarDto>> _getCigarsHandler;
    public CigarsController(IQueryHandler<GetCigars, IEnumerable<CigarDto>> getCigarsHandler)
    {
        _getCigarsHandler = getCigarsHandler;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CigarDto>>> Get([FromQuery] GetCigars query)
        => Ok(await _getCigarsHandler.HandleAsync(query));

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