using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.WorkplaceItems;

public class AddWorkplaceItemRequestHandler(IWorkplaceItemService service)
    : IEventBusRequestHandler<AddWorkplaceItemRequest, DictionaryItemModel>
{
    public async Task<DictionaryItemModel> HandleAsync(AddWorkplaceItemRequest request)
    {
        return await service.Add(request.Workplace);
    }
}