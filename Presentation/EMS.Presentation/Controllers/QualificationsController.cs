using EMS.Contracts.Records;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/qualifications")]
public class QualificationsController : ControllerBase
{
    private readonly IQualificationService _service;
    
    public QualificationsController(IServiceManager serviceManager)
    {
        _service = serviceManager.QualificationService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<QualificationModel>>> GetQualifications(Guid employeeId)
    {
        var exams = await _service.GetAll(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<QualificationModel?>> GetQualificationById(Guid employeeId, Guid id)
    {
        var qualification = await _service.GetById(id);
        return Ok(qualification);
    }

    [HttpPost]
    public async Task<ActionResult<QualificationModel>> Post(Guid employeeId, [FromBody] QualificationDto value)
    {
        var qualification = await _service.Add(employeeId, value);
        return Ok(qualification);
    }
}
