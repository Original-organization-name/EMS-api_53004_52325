using EMS.Dto.Employees;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Employees;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Employees;

[ApiController]
[Route("api/dashboard")]
public class DashboardController(IEventBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<DashboardAnalytics>> GetDashboardAnalytic()
    {
        var request = new GetDashboardAnalyticRequest();
        var result = await bus.RequestAsync<DashboardAnalytics>(request);
        return Ok(result);
    }
}   