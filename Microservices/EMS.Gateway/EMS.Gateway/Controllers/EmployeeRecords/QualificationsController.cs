using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.EmployeeRecords;

[ApiController]
[Route("api/employees/{employeeId}/qualifications")]
public class QualificationsController(IEventBus bus) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeQualifications")]
    public async Task<IEnumerable<QualificationModel>> GetQualifications(Guid employeeId)
    {
        var request = new GetEmployeeQualificationsRequest(employeeId);
        return await bus.RequestAsync<IEnumerable<QualificationModel>>(request) ?? new List<QualificationModel>();
    }

    [HttpGet("{id}", Name = "GetQualificationById")]
    public async Task<QualificationModel?> GetQualificationById(Guid employeeId, Guid id)
    {
        var request = new GetQualificationByIdRequest(id);
        return await bus.RequestAsync<QualificationModel>(request);
    }

    [HttpPost(Name = "AddQualification")]
    public async Task<QualificationModel?> Post(Guid employeeId, [FromBody] QualificationDto value)
    {
        var request = new AddQualificationRequest(employeeId, value);
        return await bus.RequestAsync<QualificationModel>(request);
    }
}
