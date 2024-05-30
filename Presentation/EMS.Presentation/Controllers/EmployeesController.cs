using EMS.DTO.Employee;
using EMS.Presentation.RequestModels;
using EMS.Presentation.ResultModels;
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
    public async Task<ActionResult<IEnumerable<EmployeeTableInfo>>> GetEmployees()
    {
        var employees = await _serviceManager.EmployeeService.GetAll();
        var result = new List<EmployeeTableInfo>();
        
        foreach (var employee in employees)
        {
            var contract = _serviceManager.ContractService.GetCurrentOrLatestContract(employee.Id);
            result.Add(new EmployeeTableInfo()
            {
                Id = employee.Id,
                Name = employee.Name, 
                Surname = employee.Surname,
                Pesel = employee.Pesel,
                ImageName = employee.ImageFileName,
                Position = contract?.PositionItemName,
                Workplace = contract?.WorkplaceItemName,
                ContractType = contract?.ContractType,
                EmploymentDate = contract?.EmploymentDate,
                TerminationDate = contract?.TerminationDate,
                Salary = contract?.Salary, 
                SalaryType = contract?.SalaryType,
                FteDenominator = contract?.FteDenominator,
                FteNumerator = contract?.FteNumerator,
                ContractStartDate = contract?.StartDate,
                BhpStatus = await _serviceManager.TrainingService.GetBhpStatus(employee.Id),
            });
        }
        
        return Ok(result);
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
            
            if (request.Contract is not null)
            {
                await _serviceManager.ContractService.Add(employee.Id, request.Contract);
            }
        }
        
        return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
    }
}
