using EMS.DTO.Records;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/medicalExaminations")]
public class MedicalExaminationsController : ControllerBase
{
    private readonly IMedicalExaminationService _service;
    
    public MedicalExaminationsController(IServiceManager serviceManager)
    {
        _service = serviceManager.MedicalExaminationService;
    }
    
    [HttpGet(Name = "GetEmployeeMedicalExams")]
    public async Task<ActionResult<IEnumerable<MedicalExaminationModel>>> GetMedicalExaminations(Guid employeeId)
    {
        var exams = await _service.GetAll(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetMedicalExamById")]
    public async Task<ActionResult<MedicalExaminationModel?>> GetMedicalExaminationById(Guid employeeId, Guid id)
    {
        var medicalExamination = await _service.GetById(id);
        return Ok(medicalExamination);
    }

    [HttpPost(Name = "UpdateMedicalExam")]
    public async Task<ActionResult<MedicalExaminationModel>> Post(Guid employeeId, [FromBody] MedicalExaminationDto value)
    {
        var medicalExamination = await _service.Add(employeeId, value);
        return Ok(medicalExamination);
    }
}
