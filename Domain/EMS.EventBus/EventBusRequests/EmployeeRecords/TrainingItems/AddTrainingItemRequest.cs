using EMS.EventBus.Abstractions;
using EMS.Shared.Abstractions.Dictionaries;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.TrainingItems;

public class AddTrainingItemRequest : IEventBusRequest
{
    public DictionaryItemDto Training { get; set; } = null!;

    public AddTrainingItemRequest(DictionaryItemDto training)
    {
        Training = training;
    }

    internal AddTrainingItemRequest()
    {
    }
}