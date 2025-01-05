using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Contracts;

[ApiController]
[Route("api/employees/{employeeId}/contracts")]
public class ContractController(IEventBus bus) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ContractModel>> GetContracts(Guid employeeId)
    {
        var request = new GetContractsRequest(employeeId);
        return await bus.RequestAsync<IEnumerable<ContractModel>>(request) ?? new List<ContractModel>();
    }

    [HttpGet("{id}")]
    public async Task<ContractModel?> GetContractById(Guid employeeId, Guid id)
    {
        var request = new GetContractsRequest(id);
        return await bus.RequestAsync<ContractModel>(request);
    }

    [HttpPost]
    public async Task<ContractModel?> Post(Guid employeeId, [FromBody] ContractDto value)
    {
        var request = new AddContractRequest(employeeId, value);
        return await bus.RequestAsync<ContractModel>(request);
    }
}
