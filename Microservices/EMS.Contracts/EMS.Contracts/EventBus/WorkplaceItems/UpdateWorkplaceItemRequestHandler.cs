using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.WorkplaceItems;

public class UpdateWorkplaceItemRequestHandler(IWorkplaceItemService service)
    : IEventBusRequestHandler<UpdateWorkplaceItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(UpdateWorkplaceItemRequest request)
    {
        return await service.Update(request.Id, request.Workplace);
    }
}