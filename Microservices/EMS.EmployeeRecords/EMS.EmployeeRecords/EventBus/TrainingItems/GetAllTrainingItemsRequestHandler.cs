using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EmployeeRecords.EventBus.TrainingItems;

public class GetAllTrainingItemsRequestHandler(ITrainingItemService service)
    : IEventBusRequestHandler<GetAllTrainingItemsRequest, IReadOnlyList<DictionaryItemModel>>
{
    public async Task<IReadOnlyList<DictionaryItemModel>> HandleAsync(GetAllTrainingItemsRequest request)
    {
        return await service.GetAllAsync();
    }
}