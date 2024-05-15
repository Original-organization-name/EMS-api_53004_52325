using EMS.Presentation.ReslutModels;
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
        var result = new DashboardAnalytics()
        {
            TotalEmployeeCount = _serviceManager.EmployeeService.Count(),
            AddInLastMonth = _serviceManager.EmployeeService.Count(x => x.CreatedAt > DateTime.Today.AddMonths(-1)),
        };
        return Ok(result);
    }
}