using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;

public class DeleteWorkplaceItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public DeleteWorkplaceItemRequest(Guid id)
    {
        Id = id;
    }

    internal DeleteWorkplaceItemRequest()
    {
    }
}