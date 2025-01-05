using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExamItems;

public class DeleteMedicalExamItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public DeleteMedicalExamItemRequest(Guid id)
    {
        Id = id;
    }

    internal DeleteMedicalExamItemRequest()
    {
    }
}