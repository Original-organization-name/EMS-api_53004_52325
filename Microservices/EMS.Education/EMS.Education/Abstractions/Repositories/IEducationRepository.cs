using EMS.Shared.Repositories;

namespace EMS.Education.Abstractions.Repositories;

public interface IEducationRepository : IBaseRepository<Domain.Education>
{
    IQueryable<Domain.Education> GetAllEmployeeEducation(Guid employeeId);
}