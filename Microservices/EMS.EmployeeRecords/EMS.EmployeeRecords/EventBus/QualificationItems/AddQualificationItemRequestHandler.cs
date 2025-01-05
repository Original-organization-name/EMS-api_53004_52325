using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.QualificationItems;

public class AddQualificationItemRequestHandler(IQualificationItemService service)
    : IEventBusRequestHandler<AddQualificationItemRequest, DictionaryItemModel>
{
    public async Task<DictionaryItemModel> HandleAsync(AddQualificationItemRequest request)
    {
        return await service.Add(request.Qualification);
    }
}