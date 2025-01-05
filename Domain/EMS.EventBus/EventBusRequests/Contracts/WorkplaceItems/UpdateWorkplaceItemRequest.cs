using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;

public class UpdateWorkplaceItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }
    public DictionaryItemDto Workplace { get; set; } = null!;

    public UpdateWorkplaceItemRequest(Guid id, DictionaryItemDto workplace)
    {
        Id = id;
        Workplace = workplace;
    }

    internal UpdateWorkplaceItemRequest()
    {
    }
}