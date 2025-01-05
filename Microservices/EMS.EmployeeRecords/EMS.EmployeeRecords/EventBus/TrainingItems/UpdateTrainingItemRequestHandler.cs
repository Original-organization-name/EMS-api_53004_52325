using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.TrainingItems;

public class UpdateTrainingItemRequestHandler(ITrainingItemService service)
    : IEventBusRequestHandler<UpdateTrainingItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(UpdateTrainingItemRequest request)
    {
        return await service.Update(request.Id, request.Training);
    }
}