using CigarBase.Application.Abstractions;
using CigarBase.Application.Commands;
using CigarBase.Application.DTO;
using CigarBase.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CigarBase.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CigarsController : ControllerBase
{
    private ICommandHandler<AddCigar> _addCigarHandler;
    private ICommandHandler<DeleteCigar> _deleteCigarHandler;
    private IQueryHandler<GetCigar, CigarDetailsDto> _getCigarHandler;
    private IQueryHandler<GetCigars, IEnumerable<CigarDto>> _getCigarsHandler;
    public CigarsController(ICommandHandler<AddCigar> addCigarHandler,
        ICommandHandler<DeleteCigar> deleteCigarHandler,
        IQueryHandler<GetCigar, CigarDetailsDto> getCigarHandler,
        IQueryHandler<GetCigars, IEnumerable<CigarDto>> getCigarsHandler)
    {
        _addCigarHandler = addCigarHandler;
        _deleteCigarHandler = deleteCigarHandler;
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
    public async Task<IActionResult> Post(AddCigar command)
    {
        command = command with { CigarId = Guid.NewGuid() };
        await _addCigarHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("{cigarId:guid}")]
    public IActionResult Put(Guid cigarId)
        => Ok();

    [HttpDelete("{cigarId:guid}")]
    public async Task<IActionResult> Delete(Guid cigarId)
    {
        await _deleteCigarHandler.HandleAsync(new DeleteCigar(cigarId));
        return Ok();
    }
}