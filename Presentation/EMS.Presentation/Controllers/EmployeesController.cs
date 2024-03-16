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
    
    // GET: api/Employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
    {
        var employees = await _employeeService.GetAll();
        return Ok(employees);
    }

    // GET: api/Employees/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<ActionResult<EmployeeModel?>> GetEmployeeById(Guid id)
    {
        var employee = await _employeeService.GetById(id);
        return Ok(employee);
    }

    // POST: api/Employees
    [HttpPost]
    public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeDto value)
    {
        var employee = await _employeeService.Add(value);
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }

    // PUT: api/Employees/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/Employees/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
