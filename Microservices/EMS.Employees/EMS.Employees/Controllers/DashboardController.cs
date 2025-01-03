using EMS.Employees.Abstractions.Services;
using EMS.Employees.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Employees.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(IEmployeeService employeeService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DashboardAnalytics>> GetDashboardAnalytic()
    {
        var recentEmployees = await employeeService.GetRecentAddedAsync();
        var recentModels = new List<EmployeeShortInfoModel>();
        
        foreach (var employee in recentEmployees)
        {
            // var contract = _serviceManager.ContractService.GetCurrentOrLatestContract(employee.Id);
            // recentModels.Add(new EmployeeShortInfoModel()
            // {
            //     Id = employee.Id,
            //     Name = employee.Name, 
            //     Surname = employee.Surname,
            //     Pesel = employee.Pesel,
            //     ImageName = employee.ImageFileName,
            //     ContractType = contract?.ContractType,
            //     EmploymentDate = contract?.EmploymentDate,
            //     TerminationDate = contract?.TerminationDate,
            //     Salary = contract?.Salary, 
            //     SalaryType = contract?.SalaryType,
            //     FteDenominator = contract?.FteDenominator,
            //     FteNumerator = contract?.FteNumerator,
            // });
        }
        
        var result = new DashboardAnalytics()
        {
            TotalEmployeeCount = employeeService.Count(),
            AddInLastMonth = employeeService.Count(x => x.CreatedAt > DateTime.Today.AddMonths(-1)),
            //TotalPayroll = _serviceManager.ContractService.CountTotalPayroll(),
            RecentAddedEmployees = recentModels,
            //ActiveContractsCount = _serviceManager.ContractService.GetActiveContractsCount(),
            //ExpiresContractCount = _serviceManager.ContractService.GetExpiresContractsCount(),
        };
        return Ok(result);
    }
}   