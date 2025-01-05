using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

public class GetTrainingByIdRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public GetTrainingByIdRequest(Guid id)
    {
        Id = id;
    }

    internal GetTrainingByIdRequest()
    {
    }
}