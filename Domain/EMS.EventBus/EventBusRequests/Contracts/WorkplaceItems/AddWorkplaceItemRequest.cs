using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.Contracts.WorkplaceItems;

public class AddWorkplaceItemRequest : IEventBusRequest
{
    public DictionaryItemDto Workplace { get; set; } = null!;

    public AddWorkplaceItemRequest(DictionaryItemDto workplace)
    {
        Workplace = workplace;
    }

    internal AddWorkplaceItemRequest()
    {
    }
}