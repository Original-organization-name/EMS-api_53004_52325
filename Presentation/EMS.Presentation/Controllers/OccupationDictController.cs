using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/occupationCode")]
public class OccupationDictController : ControllerBase
{
    private readonly IOccupationDictService _service;
    
    public OccupationDictController(IServiceManager serviceManager)
    {
        _service = serviceManager.OccupationDictService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OccupationCodeItem>>> GetDictionary()
    {
        var exams = await _service.GetAll();
        return Ok(exams);
    }
}
