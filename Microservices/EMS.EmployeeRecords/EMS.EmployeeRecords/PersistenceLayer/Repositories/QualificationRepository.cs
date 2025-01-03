using EMS.Domain.Repositories;
using EMS.EmployeeRecords.Abstractions.Repositories;
using EMS.EmployeeRecords.Domain;
using Microsoft.EntityFrameworkCore;

namespace EMS.EmployeeRecords.PersistenceLayer.Repositories;

public class QualificationRepository : BaseRepository<RecordsDbContext, Qualification>, IQualificationRepository
{
    public QualificationRepository(RecordsDbContext dbContext) : base(dbContext)
    {
    }
    
    public override IQueryable<Qualification> GetAll()
    {
        return base.GetAll().Include(item => item.QualificationItem);
    }

    public IQueryable<Qualification> GetAll(Guid employeeId)
    {
        return GetAll().Where(item => item.EmployeeId == employeeId);
    }
}