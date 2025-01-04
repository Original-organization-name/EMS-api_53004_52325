using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts;

public class GetCurrentOrLatestContractRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetCurrentOrLatestContractRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}