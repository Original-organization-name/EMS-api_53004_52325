using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Domain.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Contracts.Controllers;

[ApiController]
[Route("api/positions")]
public class PositionDictController : BaseEditableDictController<PositionItem>
{
    public PositionDictController(IPositionItemService service) : base(service)
    {
    }
}
