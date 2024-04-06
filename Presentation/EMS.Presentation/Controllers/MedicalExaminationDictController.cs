using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/examinations")]
public class MedicalExaminationDict : BaseEditableDictController<MedicalExamItem>
{
    public MedicalExaminationDict(IBaseEditableDictService<MedicalExamItem> service) : base(service)
    {
    }
}
