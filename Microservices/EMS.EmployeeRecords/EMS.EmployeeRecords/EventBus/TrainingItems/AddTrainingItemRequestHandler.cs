using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.TrainingItems;

public class AddTrainingItemRequestHandler(ITrainingItemService service)
    : IEventBusRequestHandler<AddTrainingItemRequest, DictionaryItemModel>
{
    public async Task<DictionaryItemModel> HandleAsync(AddTrainingItemRequest request)
    {
        return await service.Add(request.Training);
    }
}