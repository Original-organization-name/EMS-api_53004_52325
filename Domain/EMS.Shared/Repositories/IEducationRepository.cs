using EMS.Data.Education;

namespace EMS.Shared.Repositories;

public interface IEducationRepository : IBaseRepository<Education>
{
    IQueryable<Education> GetAllEmployeeEducation(Guid employeeId);
}