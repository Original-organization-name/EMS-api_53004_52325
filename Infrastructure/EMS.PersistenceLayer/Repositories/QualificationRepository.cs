using EMS.Data.Records;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class QualificationRepository : BaseRepository<Qualification>, IQualificationRepository
{
    public QualificationRepository(DatabaseContext dbContext) : base(dbContext)
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