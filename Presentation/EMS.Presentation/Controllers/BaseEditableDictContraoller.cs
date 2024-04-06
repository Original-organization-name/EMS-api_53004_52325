using EMS.Contracts.Dictionaries;
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
    
    [HttpGet(Name = "GetAll")]
    public async Task<ActionResult<IEnumerable<DictionaryItemModel>>> GetExaminationDict()
    {
        var examinations = await _service.GetAll();
        return Ok(examinations);
    }
    
    [HttpPost(Name = "AddItem")]
    public async Task<ActionResult<DictionaryItemModel>> Post([FromBody] DictionaryItemDto value)
    {
        var examinations = await _service.Add(value);
        return Ok(examinations);
    }
    
    [HttpPut("{id}", Name = "Update")]
    public async Task<ActionResult<DictionaryItemModel>> Update(Guid id, [FromBody] DictionaryItemDto value)
    {
        var examinations = await _service.Update(id, value);
        return Ok(examinations);
    }
        
    [HttpDelete("{id}", Name = "Delete")]
    public async Task<ActionResult<DictionaryItemModel?>> Delete(Guid id)
    {
        var examinations = await _service.Delete(id);
        return Ok(examinations);
    }
}