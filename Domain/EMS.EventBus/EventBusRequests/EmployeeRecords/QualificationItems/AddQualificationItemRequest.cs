using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;

public class AddQualificationItemRequest : IEventBusRequest
{
    public DictionaryItemDto Qualification { get; set; } = null!;

    public AddQualificationItemRequest(DictionaryItemDto qualification)
    {
        Qualification = qualification;
    }

    internal AddQualificationItemRequest()
    {
    }
}