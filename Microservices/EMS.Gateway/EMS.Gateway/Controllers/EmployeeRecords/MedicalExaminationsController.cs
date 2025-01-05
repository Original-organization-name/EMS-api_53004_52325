using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.EmployeeRecords;

[ApiController]
[Route("api/employees/{employeeId}/medicalExaminations/")]
public class MedicalExaminationsController(IEventBus bus) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeMedicalExams")]
    public async Task<IEnumerable<MedicalExaminationModel>> GetMedicalExaminations(Guid employeeId)
    {
        var request = new GetEmployeeMedicalExamsRequest(employeeId);
        return await bus.RequestAsync<IEnumerable<MedicalExaminationModel>>(request) ?? new List<MedicalExaminationModel>();
    }

    [HttpGet("{id}", Name = "GetMedicalExamById")]
    public async Task<MedicalExaminationModel?> GetMedicalExaminationById(Guid employeeId, Guid id)
    {
        var request = new GetMedicalExamByIdRequest(id);
        return await bus.RequestAsync<MedicalExaminationModel>(request);
    }

    [HttpPost(Name = "AddMedicalExam")]
    public async Task<MedicalExaminationModel?> Post(Guid employeeId, [FromBody] MedicalExaminationDto value)
    {
        var request = new AddMedicalExaminationRequest(employeeId, value);
        return await bus.RequestAsync<MedicalExaminationModel?>(request);

    }
}
