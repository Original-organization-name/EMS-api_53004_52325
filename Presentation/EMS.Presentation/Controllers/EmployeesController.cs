using EMS.Contracts.Employee;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeesController(IServiceManager serviceManager)
    {
        _employeeService = serviceManager.EmployeeService;
    }
    
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
    {
        var employees = await _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<ActionResult<EmployeeModel?>> GetEmployeeById(Guid id)
    {
        var employee = await _employeeService.GetById(id);
        return Ok(employee);
    }

    [HttpPost(Name = "AddEmployee")]
    public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeDto value)
    {
        var employee = await _employeeService.Add(value);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
}
