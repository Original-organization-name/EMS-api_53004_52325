using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.Contracts.PositionItems;

public class UpdatePositionItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }
    public DictionaryItemDto Position { get; set; } = null!;

    public UpdatePositionItemRequest(Guid id, DictionaryItemDto position)
    {
        Id = id;
        Position = position;
    }

    internal UpdatePositionItemRequest()
    {
    }
}