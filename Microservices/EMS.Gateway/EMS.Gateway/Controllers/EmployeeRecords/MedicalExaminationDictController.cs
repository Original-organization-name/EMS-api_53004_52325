using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;
using EMS.Shared.Abstractions.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.EmployeeRecords;

[ApiController]
[Route("api/examinations")]
public class MedicalExaminationDict(IEventBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<DictionaryItemModel>> GetDictionary()
    {
        var request = new GetAllMedicalExamsItemsRequest();
        return await bus.RequestAsync<IEnumerable<DictionaryItemModel>>(request) ?? new List<DictionaryItemModel>();
    }

    [HttpPost]
    public async Task<DictionaryItemModel?> Add([FromBody] DictionaryItemDto value)
    {
        var request = new AddMedicalExamItemRequest(value);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }

    [HttpPut("{id}")]
    public async Task<DictionaryItemModel?> Update(Guid id, [FromBody] DictionaryItemDto value)
    {
        var request = new UpdateMedicalExamItemRequest(id, value);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }
        
    [HttpDelete("{id}")]
    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var request = new DeleteMedicalExamItemRequest(id);
        return await bus.RequestAsync<DictionaryItemModel>(request);
    }
}
