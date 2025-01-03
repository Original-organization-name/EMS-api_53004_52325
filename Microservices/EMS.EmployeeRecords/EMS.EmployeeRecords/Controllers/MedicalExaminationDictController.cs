using EMS.Domain.Controllers;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/examinations")]
public class MedicalExaminationDict : BaseEditableDictController<MedicalExamItem>
{
    public MedicalExaminationDict(IMedicalExamItemService service) : base(service)
    {
    }
}
