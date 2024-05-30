using EMS.DTO.Employee;
using EMS.Presentation.ResultModels;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public DashboardController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }
    
    [HttpGet]
    public async Task<ActionResult<DashboardAnalytics>> GetDashboardAnalytic()
    {
        var recentEmployees = await _serviceManager.EmployeeService.GetRecentAdded();
        var recentModels = new List<EmployeeShortInfoModel>();
        
        foreach (var employee in recentEmployees)
        {
            var contract = _serviceManager.ContractService.GetCurrentOrLatestContract(employee.Id);
            recentModels.Add(new EmployeeShortInfoModel()
            {
                Id = employee.Id,
                Name = employee.Name, 
                Surname = employee.Surname,
                Pesel = employee.Pesel,
                ImageName = employee.ImageFileName,
                EmploymentDate = contract?.EmploymentDate,
                TerminationDate = contract?.TerminationDate,
                Salary = contract?.Salary, 
                SalaryType = contract?.SalaryType,
                FteDenominator = contract?.FteDenominator,
                FteNumerator = contract?.FteNumerator,
            });
        }
        
        var result = new DashboardAnalytics()
        {
            TotalEmployeeCount = _serviceManager.EmployeeService.Count(),
            AddInLastMonth = _serviceManager.EmployeeService.Count(x => x.CreatedAt > DateTime.Today.AddMonths(-1)),
            TotalPayroll = _serviceManager.ContractService.CountTotalPayroll(),
            RecentAddedEmployees = recentModels,
            ActiveContractsCount = _serviceManager.ContractService.GetActiveContractsCount(),
            ExpiresContractCount = _serviceManager.ContractService.GetExpiresContractsCount(),
        };
        return Ok(result);
    }
}   