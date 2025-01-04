using EMS.Dto.Education;
using EMS.Education.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Education.Controllers;

[ApiController]
[Route("api/education/{employeeId}")]
public class EducationController(IEducationService serviceManager) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeEducation")]
    public async Task<ActionResult<IEnumerable<EducationModel>>> GetEducation(Guid employeeId)
    {
        var exams = await serviceManager.GetAllEmployeeEducationAsync(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetEducationById")]
    public async Task<ActionResult<EducationModel?>> GetEducationById(Guid employeeId, Guid id)
    {
        var education = await serviceManager.GetById(id);
        return Ok(education);
    }

    [HttpPost(Name = "AddEducation")]
    public async Task<ActionResult<EducationModel>> Post(Guid employeeId, [FromBody] EducationDto value)
    {
        var education = await serviceManager.Add(employeeId, value);
        return Ok(education);
    }
}
