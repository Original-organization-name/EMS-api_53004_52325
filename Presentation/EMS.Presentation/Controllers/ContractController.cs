using EMS.DTO.Contracts;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees/{employeeId}/contracts")]
public class ContractController : ControllerBase
{
    private readonly IContractService _service;
    
    public ContractController(IServiceManager serviceManager)
    {
        _service = serviceManager.ContractService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContractModel>>> GetContracts(Guid employeeId)
    {
        var exams = await _service.GetAllEmployeeContracts(employeeId);
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContractModel?>> GetContractById(Guid employeeId, Guid id)
    {
        var contract = await _service.GetById(id);
        return Ok(contract);
    }

    [HttpPost]
    public async Task<ActionResult<ContractModel>> Post(Guid employeeId, [FromBody] ContractDto value)
    {
        var contract = await _service.Add(employeeId, value);
        return Ok(contract);
    }
}
