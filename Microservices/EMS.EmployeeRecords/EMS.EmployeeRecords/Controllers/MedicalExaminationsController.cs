using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/medicalExaminations/{employeeId}/")]
public class MedicalExaminationsController(IMedicalExaminationService serviceManager) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeMedicalExams")]
    public async Task<ActionResult<IEnumerable<MedicalExaminationModel>>> GetMedicalExaminations(Guid employeeId)
    {
        var exams = await serviceManager.GetAllAsync(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetMedicalExamById")]
    public async Task<ActionResult<MedicalExaminationModel?>> GetMedicalExaminationById(Guid employeeId, Guid id)
    {
        var medicalExamination = await serviceManager.GetById(id);
        return Ok(medicalExamination);
    }

    [HttpPost(Name = "UpdateMedicalExam")]
    public async Task<ActionResult<MedicalExaminationModel>> Post(Guid employeeId, [FromBody] MedicalExaminationDto value)
    {
        var medicalExamination = await serviceManager.Add(employeeId, value);
        return Ok(medicalExamination);
    }
}
