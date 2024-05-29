using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/workplaces")]
public class WorkplaceDictController : BaseEditableDictController<WorkplaceItem>
{
    public WorkplaceDictController(IBaseEditableDictService<WorkplaceItem> service) : base(service)
    {
    }
}
