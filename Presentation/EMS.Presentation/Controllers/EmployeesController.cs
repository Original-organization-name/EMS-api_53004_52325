using EMS.DTO.Employee;
using EMS.Presentation.RequestModels;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly IServiceManager _serviceManager;
    
    public EmployeesController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
    {
        var employees = await _serviceManager.EmployeeService.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<ActionResult<EmployeeModel?>> GetEmployeeById(Guid id)
    {
        var employee = await _serviceManager.EmployeeService.GetById(id);
        return Ok(employee);
    }

    [HttpPost(Name = "AddEmployee")]
    public async Task<ActionResult<EmployeeModel?>> Post([FromBody] CreateEmployeeModel request)
    {
        var employee = await _serviceManager.EmployeeService.Add(request.Employee);
        
        if (employee is not null)
        {
            if (request.MedicalExaminations is not null)
            {
                foreach (var exam in request.MedicalExaminations)
                {
                    await _serviceManager.MedicalExaminationService.Add(employee.Id, exam);
                }
            }

            if (request.Trainings is not null)
            {
                foreach (var training in request.Trainings)
                {
                    await _serviceManager.TrainingService.Add(employee.Id, training);
                }
            }

            if (request.ImageBase64 is not null)
            {
                await _serviceManager.EmployeeService.AddImage(employee.Id, request.ImageBase64);
            }
        }
        
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
}
