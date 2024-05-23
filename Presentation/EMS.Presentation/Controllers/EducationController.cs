using EMS.DTO.Experience;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/education")]
public class EducationController : ControllerBase
{
    private readonly IEducationService _service;
    
    public EducationController(IServiceManager serviceManager)
    {
        _service = serviceManager.EducationService;
    }
    
    [HttpGet(Name = "GetEmployeeEducation")]
    public async Task<ActionResult<IEnumerable<EducationModel>>> GetEducation(Guid employeeId)
    {
        var exams = await _service.GetAllEmployeeEducation(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetEducationById")]
    public async Task<ActionResult<EducationModel?>> GetEducationById(Guid employeeId, Guid id)
    {
        var education = await _service.GetById(id);
        return Ok(education);
    }

    [HttpPost(Name = "AddEducation")]
    public async Task<ActionResult<EducationModel>> Post(Guid employeeId, [FromBody] EducationDto value)
    {
        var education = await _service.Add(employeeId, value);
        return Ok(education);
    }
}
