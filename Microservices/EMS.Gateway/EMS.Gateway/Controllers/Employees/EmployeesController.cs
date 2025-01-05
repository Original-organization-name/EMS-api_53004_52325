using EMS.Dto.Employees;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Employees;

[ApiController]
[Route("api/employees")]
public class EmployeesController(IEventBus bus) : ControllerBase
{
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<IEnumerable<EmployeeTableInfo>> GetEmployees()
    {
        var request = new GetEmployeesRequest();
        return await bus.RequestAsync<IEnumerable<EmployeeTableInfo>>(request) ?? new List<EmployeeTableInfo>();
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<EmployeeModel?> GetEmployeeById(Guid id)
    {
        var request = new GetEmployeeByIdRequest(id);
        return await bus.RequestAsync<EmployeeModel>(request);
    }

    [HttpPost(Name = "AddEmployee")]
    public async Task<ActionResult<EmployeeModel?>> Post([FromBody] CreateEmployeeModel model)
    {
        var request = new AddEmployeeRequest(model);
        var employee = await bus.RequestAsync<EmployeeModel>(request);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee!.Id }, employee);
    }
    
    
    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public async Task<ActionResult<EmployeeModel?>> Delete(Guid id)
    {
        var request = new DeleteEmployeeRequest(id);
        return await bus.RequestAsync<EmployeeModel?>(request);
    }
}
