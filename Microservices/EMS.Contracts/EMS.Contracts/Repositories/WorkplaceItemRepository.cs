using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Contracts.PersistenceLayer;
using EMS.Domain.Repositories;

namespace EMS.Contracts.Repositories;

public class WorkplaceItemRepository : BaseEditableDictRepository<ContractsDbContext, WorkplaceItem>, IWorkplaceItemRepository
{
    public WorkplaceItemRepository(ContractsDbContext dbContext) : base(dbContext)
    {
    }
}