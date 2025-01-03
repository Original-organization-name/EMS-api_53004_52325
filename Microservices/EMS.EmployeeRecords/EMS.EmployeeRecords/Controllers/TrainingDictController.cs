using EMS.Shared.Controllers;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace EMS.EmployeeRecords.Controllers;

[ApiController]
[Route("api/trainings")]
public class TrainingDictController : BaseEditableDictController<TrainingItem>
{
    public TrainingDictController(ITrainingItemService service) : base(service)
    {
    }
}
