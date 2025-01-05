using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.WorkplaceItems;

public class DeleteWorkplaceItemRequestHandler(IWorkplaceItemService service)
    : IEventBusRequestHandler<DeleteWorkplaceItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(DeleteWorkplaceItemRequest request)
    {
        return await service.Delete(request.Id);
    }
}