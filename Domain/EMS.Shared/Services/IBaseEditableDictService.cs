using EMS.DTO.Dictionaries;
using EMS.Data.Models;

namespace EMS.Shared.Services;

public interface IBaseEditableDictService<T> where T : EditableDictionaryItem
{
    public Task<IReadOnlyList<DictionaryItemModel>> GetAll();
    public Task<DictionaryItemModel> Add(DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Delete(Guid id);
}