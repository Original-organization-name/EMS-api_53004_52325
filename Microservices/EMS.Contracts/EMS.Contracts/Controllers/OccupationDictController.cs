using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Contracts.Controllers;

[ApiController]
[Route("api/occupationCode")]
public class OccupationDictController(IOccupationDictService service)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OccupationCodeItem>>> GetDictionary()
    {
        var exams = await service.GetAll();
        return Ok(exams);
    }
}
