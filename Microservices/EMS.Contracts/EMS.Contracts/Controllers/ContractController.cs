using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Contracts.Controllers;

[ApiController]
[Route("api/contracts/{employeeId}/")]
public class ContractController(IContractService contractService) 
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractModel>>> GetContracts(Guid employeeId)
    {
        var exams = await contractService.GetAllEmployeeContractsAsync(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractModel?>> GetContractById(Guid employeeId, Guid id)
    {
        var contract = await contractService.GetById(id);
        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult<ContractModel>> Post(Guid employeeId, [FromBody] ContractDto value)
    {
        var contract = await contractService.Add(employeeId, value);
        return Ok(contract);
    }
}
