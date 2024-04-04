using EMS.Contracts.Dictionaries;

namespace EMS.Shared.Services;

public interface ITrainingDictService
{
    Task<IReadOnlyList<DictionaryItemModel>> GetAll();
    Task<DictionaryItemModel> Add(DictionaryItemDto newItem);
    Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem);
    Task<DictionaryItemModel?> Delete(Guid id);
}