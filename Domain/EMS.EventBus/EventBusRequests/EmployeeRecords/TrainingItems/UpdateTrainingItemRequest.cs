using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;

public class UpdateTrainingItemRequest : IEventBusRequest
{
    public Guid Id { get; set; }
    public DictionaryItemDto Training { get; set; } = null!;

    public UpdateTrainingItemRequest(Guid id, DictionaryItemDto training)
    {
        Id = id;
        Training = training;
    }

    internal UpdateTrainingItemRequest()
    {
    }
}