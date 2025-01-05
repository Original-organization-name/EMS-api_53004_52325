using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.QualificationItems;

public class DeleteQualificationItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public DeleteQualificationItemRequest(Guid id)
    {
        Id = id;
    }

    internal DeleteQualificationItemRequest()
    {
    }
}