using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class TrainingItemRepository : BaseEditableDictRepository<RecordsDbContext, TrainingItem>, ITrainingItemRepository
{
    public TrainingItemRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }
}