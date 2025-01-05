using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords;

public class GetBhpStatusRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }
    
    public GetBhpStatusRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    public GetBhpStatusRequest()
    {
        
    }
}