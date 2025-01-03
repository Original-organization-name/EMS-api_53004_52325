using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Shared.Repositories;

namespace EMS.Contracts.PersistenceLayer.Repositories;

public class WorkplaceItemRepository : BaseEditableDictRepository<ContractsDbContext, WorkplaceItem>, IWorkplaceItemRepository
{
    public WorkplaceItemRepository(ContractsDbContext dbContext) : base(dbContext)
    {
    }
}