using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts;

public class GetContractsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetContractsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal GetContractsRequest()
    {
        
    }
}