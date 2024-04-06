using EMS.Contracts.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/examination")]
public class MedicalExaminationDict : ControllerBase
{
    private readonly IMedicalExaminationDictService _service;
    
    public MedicalExaminationDict(IServiceManager serviceManager)
    {
        _service = serviceManager.MedicalExaminationDictService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DictionaryItemModel>>> GetExaminationDict()
    {
        var examinations = await _service.GetAll();
        return Ok(examinations);
    }
    
    [HttpPost]
    public async Task<ActionResult<DictionaryItemModel>> Post([FromBody] DictionaryItemDto value)
    {
        var examinations = await _service.Add(value);
        return Ok(examinations);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<DictionaryItemModel>> Update(Guid id, [FromBody] DictionaryItemDto value)
    {
        var examinations = await _service.Update(id, value);
        return Ok(examinations);
    }
        
    [HttpDelete("{id}")]
    public async Task<ActionResult<DictionaryItemModel?>> Delete(Guid id)
    {
        var examinations = await _service.Delete(id);
        return Ok(examinations);
    }
}
