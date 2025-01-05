using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.PositionItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.PositionItems;

public class UpdatePositionItemRequestHandler(IPositionItemService service)
    : IEventBusRequestHandler<UpdatePositionItemRequest, DictionaryItemModel?>
{
    public async Task<DictionaryItemModel?> HandleAsync(UpdatePositionItemRequest request)
    {
        return await service.Update(request.Id, request.Position);
    }
}