using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain.Dictionaries;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class MedicalExamItemRepository : BaseEditableDictRepository<RecordsDbContext, MedicalExamItem>, IMedicalExamItemRepository
{
    public MedicalExamItemRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }
}