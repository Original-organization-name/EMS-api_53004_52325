using EMS.Data.Contracts;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
    public ContractRepository(DatabaseContext dbContext) : base(dbContext)
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