using EMS.Contracts.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/trainings")]
public class TrainingDictController : ControllerBase
{
    private readonly ITrainingDictService _service;
    
    public TrainingDictController(IServiceManager serviceManager)
    {
        _service = serviceManager.TrainingDictService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DictionaryItemModel>>> GetTrainingDict()
    {
        var trainings = await _service.GetAll();
        return Ok(trainings);
    }
    
    [HttpPost]
    public async Task<ActionResult<DictionaryItemModel>> Post([FromBody] DictionaryItemDto value)
    {
        var training = await _service.Add(value);
        return Ok(training);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<DictionaryItemModel>> Update(Guid id, [FromBody] DictionaryItemDto value)
    {
        var training = await _service.Update(id, value);
        return Ok(training);
    }
        
    [HttpDelete("{id}")]
    public async Task<ActionResult<DictionaryItemModel?>> Delete(Guid id)
    {
        var training = await _service.Delete(id);
        return Ok(training);
    }
}
