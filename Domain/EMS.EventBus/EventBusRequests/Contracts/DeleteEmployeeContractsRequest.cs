using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts;

public class DeleteEmployeeContractsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public DeleteEmployeeContractsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal DeleteEmployeeContractsRequest()
    {
        
    }
}