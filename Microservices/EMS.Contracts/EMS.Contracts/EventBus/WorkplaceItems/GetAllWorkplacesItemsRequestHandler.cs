using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.WorkplaceItems;

public class GetAllWorkplacesItemsRequestHandler(IWorkplaceItemService service)
    : IEventBusRequestHandler<GetAllWorkplacesItemsRequest, IReadOnlyList<DictionaryItemModel>>
{
    public async Task<IReadOnlyList<DictionaryItemModel>> HandleAsync(GetAllWorkplacesItemsRequest request)
    {
        return await service.GetAllAsync();
    }
}