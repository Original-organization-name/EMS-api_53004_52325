using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.Contracts.PositionItems;

public class AddPositionItemRequest : IEventBusRequest
{
    public DictionaryItemDto Position { get; set; } = null!;

    public AddPositionItemRequest(DictionaryItemDto position)
    {
        Position = position;
    }

    internal AddPositionItemRequest()
    {
    }
}