using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/qualifications")]
public class QualificationDictController : BaseEditableDictController<QualificationItem>
{
    public QualificationDictController(IBaseEditableDictService<QualificationItem> service) : base(service)
    {
    }
}
