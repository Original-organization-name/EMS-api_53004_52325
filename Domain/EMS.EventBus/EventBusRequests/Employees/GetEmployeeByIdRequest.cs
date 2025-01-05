using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Employees;

public class GetEmployeeByIdRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetEmployeeByIdRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    public GetEmployeeByIdRequest()
    {
        
    }
}