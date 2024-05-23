using EMS.Data.Experience;

namespace EMS.Shared.Repositories;

public interface IEducationRepository : IBaseRepository<Education>
{
    IQueryable<Education> GetAllEmployeeEducation(Guid employeeId);
}