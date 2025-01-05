using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Employees;

public class DeleteEmployeeRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public DeleteEmployeeRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
    
    internal DeleteEmployeeRequest()
    {
        
    }
}