using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.QualificationItems;

public class UpdateQualificationItemRequestHandler(IQualificationItemService service)
    : IEventBusRequestHandler<UpdateQualificationItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(UpdateQualificationItemRequest request)
    {
        return await service.Update(request.Id, request.Qualification);
    }
}