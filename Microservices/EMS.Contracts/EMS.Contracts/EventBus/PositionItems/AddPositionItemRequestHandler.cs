using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.PositionItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.PositionItems;

public class AddPositionItemRequestHandler(IPositionItemService service)
    : IEventBusRequestHandler<AddPositionItemRequest, DictionaryItemModel>
{
    public async Task<DictionaryItemModel> HandleAsync(AddPositionItemRequest request)
    {
        return await service.Add(request.Position);
    }
}