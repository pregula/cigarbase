using CigarBase.Application.Abstractions;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarsController : ControllerBase
{
    private IQueryHandler<GetCigar, CigarDetailsDto> _getCigarHandler;
    private IQueryHandler<GetCigars, IEnumerable<CigarDto>> _getCigarsHandler;
    public CigarsController(IQueryHandler<GetCigar, CigarDetailsDto> getCigarHandler,
        IQueryHandler<GetCigars, IEnumerable<CigarDto>> getCigarsHandler)
    {
        _getCigarHandler = getCigarHandler;
        _getCigarsHandler = getCigarsHandler;
    }

    [HttpGet("{cigarId:guid}")]
    public async Task<ActionResult<CigarDetailsDto>> Get(Guid cigarId)
    {
        var cigar = await _getCigarHandler.HandleAsync(new GetCigar { CigarId = cigarId });
        if (cigar is null)
        {
            return NotFound();
        }

        return cigar;
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