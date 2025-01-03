using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Domain.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Contracts.Controllers;

[ApiController]
[Route("api/workplaces")]
public class WorkplaceDictController : BaseEditableDictController<WorkplaceItem>
{
    public WorkplaceDictController(IWorkplaceItemService service) : base(service)
    {
    }
}
