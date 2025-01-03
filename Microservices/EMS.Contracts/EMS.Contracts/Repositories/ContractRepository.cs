using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Entities;
using EMS.Contracts.PersistenceLayer;
using EMS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.Repositories;

public class ContractRepository : BaseRepository<ContractsDbContext, Contract>, IContractRepository
{
    public ContractRepository(ContractsDbContext dbContext) : base(dbContext)
    {
    }

    public override IQueryable<Contract> GetAll()
    {
        return base.GetAll()
            .Include(employee => employee.PositionItem)
            .Include(employee => employee.WorkplaceItem)
            .Include(employee => employee.OccupationCodeItem);
    } 
    
    public IQueryable<Contract> GetAll(Guid employeeId)
    {
        return FindByCondition(x => x.EmployeeId == employeeId);
    }
}