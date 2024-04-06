using EMS.Data.Dictionaries;
using EMS.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Presentation.Controllers;

[ApiController]
[Route("api/trainings")]
public class TrainingDictController : BaseEditableDictController<TrainingItem>
{
    public TrainingDictController(IBaseEditableDictService<TrainingItem> service) : base(service)
    {
    }
}
