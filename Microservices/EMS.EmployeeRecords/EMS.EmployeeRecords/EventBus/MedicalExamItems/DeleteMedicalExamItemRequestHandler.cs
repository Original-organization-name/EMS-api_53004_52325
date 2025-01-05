using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.MedicalExamItems;

public class DeleteMedicalExamItemRequestHandler(IMedicalExamItemService service)
    : IEventBusRequestHandler<DeleteMedicalExamItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(DeleteMedicalExamItemRequest request)
    {
        return await service.Delete(request.Id);
    }
}