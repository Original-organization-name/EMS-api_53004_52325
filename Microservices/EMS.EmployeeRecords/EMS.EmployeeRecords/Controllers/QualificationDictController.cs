using EMS.Domain.Controllers;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/qualifications")]
public class QualificationDictController : BaseEditableDictController<QualificationItem>
{
    public QualificationDictController(IQualificationItemService service) : base(service)
    {
    }
}
