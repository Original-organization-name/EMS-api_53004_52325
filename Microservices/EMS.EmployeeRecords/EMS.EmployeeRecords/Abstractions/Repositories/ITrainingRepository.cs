using EMS.Shared.Repositories;
using EMS.EmployeeRecords.Domain;

namespace EMS.EmployeeRecords.Abstractions.Repositories;

public interface ITrainingRepository : IBaseRepository<Training>
{
    IQueryable<Training> GetAll(Guid employeeId);
    
    Task<IEnumerable<Training>> DeleteByEmployeeIdAsync(Guid employeeId);
}