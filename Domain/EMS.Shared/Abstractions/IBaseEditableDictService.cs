using EMS.Shared.Abstractions.Dictionaries;
using EMS.Shared.Models;

namespace EMS.Shared.Abstractions;

public interface IBaseEditableDictService<T> where T : EditableDictionaryItem
{
    public Task<IReadOnlyList<DictionaryItemModel>> GetAllAsync();
    public Task<DictionaryItemModel> Add(DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Delete(Guid id);
}