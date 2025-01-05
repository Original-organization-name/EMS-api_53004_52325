using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.PositionItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.PositionItems;

public class DeletePositionItemRequestHandler(IPositionItemService service)
    : IEventBusRequestHandler<DeletePositionItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(DeletePositionItemRequest request)
    {
        return await service.Delete(request.Id);
    }
}