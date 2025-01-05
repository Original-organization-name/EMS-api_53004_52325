using EMS.Contracts.Domain.Entities;
using EMS.Shared.Repositories;

namespace EMS.Contracts.Abstractions.Repositories;

public interface IContractRepository : IBaseRepository<Contract>
{
    IQueryable<Contract> GetAll(Guid employeeId);
    
    Task<IEnumerable<Contract>> DeleteByEmployeeIdAsync(Guid employeeId);
}