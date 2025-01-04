using EMS.Dto.Contracts;
using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests;
using EMS.EventBus.EventBusRequests.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Employees.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(IEmployeeService employeeService, IEventBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DashboardAnalytics>> GetDashboardAnalytic()
    {
        var recentEmployees = await employeeService.GetRecentAddedAsync();
        var recentModels = new List<EmployeeShortInfoModel>();
        
        foreach (var employee in recentEmployees)
        {
            var contract = await bus.RequestAsync<ContractModel>(new GetCurrentOrLatestContractRequest(employee.Id));
            recentModels.Add(new EmployeeShortInfoModel()
            {
                Id = employee.Id,
                Name = employee.Name, 
                Surname = employee.Surname,
                Pesel = employee.Pesel,
                ImageName = employee.ImageFileName,
                ContractType = contract?.ContractType,
                EmploymentDate = contract?.EmploymentDate,
                TerminationDate = contract?.TerminationDate,
                Salary = contract?.Salary, 
                SalaryType = contract?.SalaryType,
                FteDenominator = contract?.FteDenominator,
                FteNumerator = contract?.FteNumerator,
            });
        }
        
        var totalPayroll = await bus.RequestAsync<decimal>(new CountTotalPayrollRequest());
        var activeContractsCount = await bus.RequestAsync<int>(new GetActiveContractsCountRequest());
        var expiresContractCount = await bus.RequestAsync<int>(new GetExpiresContractsCountRequest());
        var result = new DashboardAnalytics()
        {
            TotalEmployeeCount = employeeService.Count(),
            AddInLastMonth = employeeService.Count(x => x.CreatedAt > DateTime.Today.AddMonths(-1)),
            TotalPayroll = totalPayroll,
            RecentAddedEmployees = recentModels,
            ActiveContractsCount = activeContractsCount,
            ExpiresContractCount = expiresContractCount,
        };
        return Ok(result);
    }
}   