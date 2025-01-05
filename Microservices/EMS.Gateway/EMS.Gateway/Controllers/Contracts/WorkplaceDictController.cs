using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;
using EMS.Shared.Abstractions.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Contracts;

[ApiController]
[Route("api/workplaces")]
public class WorkplaceDictController(IEventBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<DictionaryItemModel>> GetDictionary()
    {
        var request = new GetAllWorkplacesItemsRequest();
        return await bus.RequestAsync<IEnumerable<DictionaryItemModel>>(request) ?? new List<DictionaryItemModel>();
    }

    [HttpPost]
    public async Task<DictionaryItemModel?> Add([FromBody] DictionaryItemDto value)
    {
        var request = new AddWorkplaceItemRequest(value);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }

    [HttpPut("{id}")]
    public async Task<DictionaryItemModel?> Update(Guid id, [FromBody] DictionaryItemDto value)
    {
        var request = new UpdateWorkplaceItemRequest(id, value);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }
        
    [HttpDelete("{id}")]
    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var request = new DeleteWorkplaceItemRequest(id);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }
}
