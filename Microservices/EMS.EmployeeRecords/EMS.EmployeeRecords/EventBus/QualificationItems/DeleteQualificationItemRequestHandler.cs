using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.QualificationItems;

public class DeleteQualificationItemRequestHandler(IQualificationItemService service)
    : IEventBusRequestHandler<DeleteQualificationItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(DeleteQualificationItemRequest request)
    {
        return await service.Delete(request.Id);
    }
}