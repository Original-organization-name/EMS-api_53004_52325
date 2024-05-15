using EMS.DTO.Records;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/trainings")]
public class TrainingsController : ControllerBase
{
    private readonly ITrainingService _service;
    
    public TrainingsController(IServiceManager serviceManager)
    {
        _service = serviceManager.TrainingService;
    }
    
    [HttpGet(Name = "GetEmployeeTrainings")]
    public async Task<ActionResult<IEnumerable<TrainingModel>>> GetTrainings(Guid employeeId)
    {
        var exams = await _service.GetAll(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}", Name = "GetTrainingById")]
    public async Task<ActionResult<TrainingModel?>> GetTrainingById(Guid employeeId, Guid id)
    {
        var training = await _service.GetById(id);
        return Ok(training);
    }

    [HttpPost(Name = "AddTraining")]
    public async Task<ActionResult<TrainingModel>> Post(Guid employeeId, [FromBody] TrainingDto value)
    {
        var training = await _service.Add(employeeId, value);
        return Ok(training);
    }
}
