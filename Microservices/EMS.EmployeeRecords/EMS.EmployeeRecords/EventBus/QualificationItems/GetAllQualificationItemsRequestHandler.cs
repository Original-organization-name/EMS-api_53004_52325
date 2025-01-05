using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.QualificationItems;

public class GetAllQualificationItemsRequestHandler(IQualificationItemService service)
    : IEventBusRequestHandler<GetAllQualificationItemsRequest, IReadOnlyList<DictionaryItemModel>>
{
    public async Task<IReadOnlyList<DictionaryItemModel>> HandleAsync(GetAllQualificationItemsRequest request)
    {
        return await service.GetAllAsync();
    }
}