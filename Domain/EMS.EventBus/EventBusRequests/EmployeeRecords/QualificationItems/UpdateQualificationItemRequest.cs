using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;

public class UpdateQualificationItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }
    public DictionaryItemDto Qualification { get; set; } = null!;

    public UpdateQualificationItemRequest(Guid id, DictionaryItemDto qualification)
    {
        Id = id;
        Qualification = qualification;
    }

    internal UpdateQualificationItemRequest()
    {
    }
}