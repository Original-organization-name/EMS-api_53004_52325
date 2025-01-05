using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts.PositionItems;

public class DeletePositionItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public DeletePositionItemRequest(Guid id)
    {
        Id = id;
    }

    internal DeletePositionItemRequest()
    {
    }
}