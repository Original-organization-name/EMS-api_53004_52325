using EMS.Dto.Education;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Education;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Education;

[ApiController]
[Route("api/employees/{employeeId}/education")]
public class EducationController(IEventBus bus) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeEducation")]
    public async Task<IEnumerable<EducationModel>> GetEducation(Guid employeeId)
    {
        var request = new GetEducationRequest(employeeId);
        return await bus.RequestAsync<IEnumerable<EducationModel>>(request) ?? new List<EducationModel>();
    }

    [HttpGet("{id}", Name = "GetEducationById")]
    public async Task<EducationModel?> GetEducationById(Guid employeeId, Guid id)
    {
        var request = new GetEducationByIdRequest(id);
        return await bus.RequestAsync<EducationModel>(request);
    }

    [HttpPost(Name = "AddEducation")]
    public async Task<EducationModel> Post(Guid employeeId, [FromBody] EducationDto value)
    {
        var request = new AddEducationRequest(employeeId, value);
        return (await bus.RequestAsync<EducationModel>(request))!;
    }
}
