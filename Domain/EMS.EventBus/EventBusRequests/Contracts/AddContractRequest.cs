using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts;

public class AddContractRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public ContractDto Contract { get; set; } = null!;

    public AddContractRequest(Guid employeeId, ContractDto contract)
    {
        EmployeeId = employeeId;
        Contract = contract;
    }

    internal AddContractRequest()
    {
        
    }
}