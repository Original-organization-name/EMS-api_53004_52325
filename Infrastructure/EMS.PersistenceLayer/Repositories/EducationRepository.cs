using EMS.Data.Experience;
using EMS.Shared.Repositories;

namespace EMS.PersistenceLayer.Repositories;

public class EducationRepository : BaseRepository<Education>, IEducationRepository
{
    public EducationRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Education> GetAllEmployeeEducation(Guid employeeId)
    {
        return FindByCondition(x => x.EmployeeId == employeeId);
    }
}