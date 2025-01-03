using EMS.Domain.Abstractions.Dictionaries;
using EMS.Domain.Models;

namespace EMS.Domain.Abstractions;

public interface IBaseEditableDictService<T> where T : EditableDictionaryItem
{
    public Task<IReadOnlyList<DictionaryItemModel>> GetAllAsync();
    public Task<DictionaryItemModel> Add(DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Delete(Guid id);
}