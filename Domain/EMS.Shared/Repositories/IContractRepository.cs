using EMS.Data.Contracts;

namespace EMS.Shared.Repositories;

public interface IContractRepository : IBaseRepository<Contract>
{
    IQueryable<Contract> GetAll(Guid employeeId);
}