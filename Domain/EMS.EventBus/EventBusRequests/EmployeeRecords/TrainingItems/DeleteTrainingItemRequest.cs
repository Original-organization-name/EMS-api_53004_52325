using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;

public class DeleteTrainingItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public DeleteTrainingItemRequest(Guid id)
    {
        Id = id;
    }

    internal DeleteTrainingItemRequest()
    {
    }
}