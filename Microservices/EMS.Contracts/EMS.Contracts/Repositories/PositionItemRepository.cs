using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Contracts.PersistenceLayer;
using EMS.Domain.Repositories;

namespace EMS.Contracts.Repositories;

public class PositionItemRepository : BaseEditableDictRepository<ContractsDbContext, PositionItem>, IPositionItemRepository
{
    public PositionItemRepository(ContractsDbContext dbContext) : base(dbContext)
    {
    }
}