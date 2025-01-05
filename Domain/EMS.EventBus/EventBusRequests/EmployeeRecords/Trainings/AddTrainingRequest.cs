using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

public class AddTrainingRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public TrainingDto Training { get; set; } = null!;
    
    public AddTrainingRequest(Guid employeeId, TrainingDto training)
    {
        EmployeeId = employeeId;
        Training = training;
    }

    internal AddTrainingRequest()
    {
    }
}