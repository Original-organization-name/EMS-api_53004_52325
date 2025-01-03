using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Shared.Repositories;

namespace EMS.Contracts.PersistenceLayer.Repositories;

public class PositionItemRepository : BaseEditableDictRepository<ContractsDbContext, PositionItem>, IPositionItemRepository
{
    public PositionItemRepository(ContractsDbContext dbContext) : base(dbContext)
    {
    }
}