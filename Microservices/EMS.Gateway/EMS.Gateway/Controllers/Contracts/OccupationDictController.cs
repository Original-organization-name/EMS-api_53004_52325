using EMS.Dto.Contracts;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Gateway.Controllers.Contracts;

[ApiController]
[Route("api/occupationCode")]
public class OccupationDictController(IEventBus bus) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<OccupationCodeItemModel>> GetDictionary()
    {
        var request = new GetOccupationCodesRequest();
        return await bus.RequestAsync<IEnumerable<OccupationCodeItemModel>>(request) ?? new List<OccupationCodeItemModel>();
    }
}
