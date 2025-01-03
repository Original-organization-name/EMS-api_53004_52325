using EMS.Contracts.Domain.Entities;
using EMS.Domain.Repositories;

namespace EMS.Contracts.Abstractions.Repositories;

public interface IContractRepository : IBaseRepository<Contract>
{
    IQueryable<Contract> GetAll(Guid employeeId);
}