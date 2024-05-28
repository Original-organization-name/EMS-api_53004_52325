using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionDictController : BaseEditableDictController<PositionItem>
{
    public PositionDictController(IBaseEditableDictService<PositionItem> service) : base(service)
    {
    }
}
