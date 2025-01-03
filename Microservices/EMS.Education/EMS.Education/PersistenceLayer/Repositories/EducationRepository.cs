using EMS.Domain.Repositories;
using EMS.Education.Abstractions.Repositories;

namespace EMS.Education.PersistenceLayer.Repositories;

public class EducationRepository : BaseRepository<EducationDbContext, Domain.Education>, IEducationRepository
{
    public EducationRepository(EducationDbContext dbContext) : base(dbContext)
    {
    }

    public IQueryable<Domain.Education> GetAllEmployeeEducation(Guid employeeId)
    {
        return FindByCondition(x => x.EmployeeId == employeeId);
    }
}