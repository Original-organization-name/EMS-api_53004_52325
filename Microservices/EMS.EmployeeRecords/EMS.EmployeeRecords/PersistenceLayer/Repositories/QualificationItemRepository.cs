using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class QualificationItemRepository : BaseEditableDictRepository<RecordsDbContext, QualificationItem>, IQualificationItemRepository
{
    public QualificationItemRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }
}