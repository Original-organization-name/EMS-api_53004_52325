using EMS.Shared.Services;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Abstractions.Services;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.Services;

public class TrainingItemService : BaseEditableDictService<TrainingItem>, ITrainingItemService
{
    public TrainingItemService(ITrainingItemRepository repository) : base(repository)
    {
    }
}