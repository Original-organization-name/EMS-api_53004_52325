using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.EmployeeRecords;

[ApiController]
[Route("api/employees/{employeeId}/trainings")]
public class TrainingsController(IEventBus bus) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeTrainings")]
    public async Task<IEnumerable<TrainingModel>> GetTrainings(Guid employeeId)
    {
        var request = new GetEmployeeTrainingsRequest(employeeId);
        return await bus.RequestAsync<IEnumerable<TrainingModel>>(request) ?? new List<TrainingModel>();
    }

    [HttpGet("{id}", Name = "GetTrainingById")]
    public async Task<TrainingModel?> GetTrainingById(Guid employeeId, Guid id)
    {
        var request = new GetTrainingByIdRequest(id);
        return await bus.RequestAsync<TrainingModel>(request);
    }

    [HttpPost(Name = "AddTraining")]
    public async Task<TrainingModel?> Post(Guid employeeId, [FromBody] TrainingDto value)
    {
        var request = new AddTrainingRequest(employeeId, value);
        return await bus.RequestAsync<TrainingModel>(request);
    }
}
