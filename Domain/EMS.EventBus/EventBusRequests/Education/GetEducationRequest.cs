using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Education;

public class GetEducationRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetEducationRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal GetEducationRequest()
    {
        
    }
}