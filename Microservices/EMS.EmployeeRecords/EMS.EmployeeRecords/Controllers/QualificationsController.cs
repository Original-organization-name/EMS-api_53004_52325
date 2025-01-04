using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/qualifications")]
public class QualificationsController(IQualificationService serviceManager) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeQualifications")]
    public async Task<ActionResult<IEnumerable<QualificationModel>>> GetQualifications(Guid employeeId)
    {
        var exams = await serviceManager.GetAllAsync(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetQualificationById")]
    public async Task<ActionResult<QualificationModel?>> GetQualificationById(Guid employeeId, Guid id)
    {
        var qualification = await serviceManager.GetById(id);
        return Ok(qualification);
    }

    [HttpPost(Name = "AddQualification")]
    public async Task<ActionResult<QualificationModel>> Post(Guid employeeId, [FromBody] QualificationDto value)
    {
        var qualification = await serviceManager.Add(employeeId, value);
        return Ok(qualification);
    }
}
