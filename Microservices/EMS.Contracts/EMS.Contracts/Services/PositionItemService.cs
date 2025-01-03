using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Dictionaries;
using EMS.Shared.Services;

namespace EMS.Contracts.Services;

public class PositionItemService : BaseEditableDictService<PositionItem>, IPositionItemService
{
    public PositionItemService(IPositionItemRepository repository) : base(repository)
    {
    }
}