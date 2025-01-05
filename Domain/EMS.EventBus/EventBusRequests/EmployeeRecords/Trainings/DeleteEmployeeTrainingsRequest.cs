using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;

public class DeleteEmployeeTrainingsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    
    public DeleteEmployeeTrainingsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal DeleteEmployeeTrainingsRequest()
    {
    }
}