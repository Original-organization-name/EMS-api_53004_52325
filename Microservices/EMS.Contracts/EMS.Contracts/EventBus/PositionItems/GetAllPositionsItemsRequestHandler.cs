using EMS.Contracts.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts.PositionItems;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.Contracts.EventBus.PositionItems;

public class GetAllPositionsItemsRequestHandler(IPositionItemService service)
    : IEventBusRequestHandler<GetAllPositionsItemsRequest, IReadOnlyList<DictionaryItemModel>>
{
    public async Task<IReadOnlyList<DictionaryItemModel>> HandleAsync(GetAllPositionsItemsRequest request)
    {
        return await service.GetAllAsync();
    }
}