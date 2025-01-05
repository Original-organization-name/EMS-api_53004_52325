using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.TrainingItems;

public class DeleteTrainingItemRequestHandler(ITrainingItemService service)
    : IEventBusRequestHandler<DeleteTrainingItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(DeleteTrainingItemRequest request)
    {
        return await service.Delete(request.Id);
    }
}