using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Shared.Services;

namespace EMS.Contracts.Services;

public class WorkplaceItemService : BaseEditableDictService<WorkplaceItem>, IWorkplaceItemService
{
    public WorkplaceItemService(IWorkplaceItemRepository repository) : base(repository)
    {
    }
}