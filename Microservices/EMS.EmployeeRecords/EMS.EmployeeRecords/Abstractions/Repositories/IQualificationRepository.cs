using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Domain;

namespace EMS.EmployeeRecords.Abstractions.Repositories;

public interface IQualificationRepository : IBaseRepository<Qualification>
{
    IQueryable<Qualification> GetAll(Guid employeeId);
}