using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

public class GetEmployeeTrainingsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetEmployeeTrainingsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal GetEmployeeTrainingsRequest()
    {
    }
}