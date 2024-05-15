using EMS.DTO.Dictionaries;
using EMS.Data.Models;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

public abstract class BaseEditableDictController<T> : ControllerBase
    where T : EditableDictionaryItem
{
    
    private readonly IBaseEditableDictService<T> _service;

    protected BaseEditableDictController(IBaseEditableDictService<T> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DictionaryItemModel>>> GetDictionary()
    {
        var examinations = await _service.GetAll();
        return Ok(examinations);
    }
    
    [HttpPost]
    public async Task<ActionResult<DictionaryItemModel>> Add([FromBody] DictionaryItemDto value)
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