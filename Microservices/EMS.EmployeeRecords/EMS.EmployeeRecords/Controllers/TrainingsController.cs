using EMS.Dto.EmployeeRecords;
using EMS.EmployeeRecords.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/trainings")]
public class TrainingsController(ITrainingService serviceManager) : ControllerBase
{
    [HttpGet(Name = "GetEmployeeTrainings")]
    public async Task<ActionResult<IEnumerable<TrainingModel>>> GetTrainings(Guid employeeId)
    {
        var exams = await serviceManager.GetAllAsync(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetTrainingById")]
    public async Task<ActionResult<TrainingModel?>> GetTrainingById(Guid employeeId, Guid id)
    {
        var training = await serviceManager.GetById(id);
        return Ok(training);
    }

    [HttpPost(Name = "AddTraining")]
    public async Task<ActionResult<TrainingModel>> Post(Guid employeeId, [FromBody] TrainingDto value)
    {
        var training = await serviceManager.Add(employeeId, value);
        return Ok(training);
    }
}
