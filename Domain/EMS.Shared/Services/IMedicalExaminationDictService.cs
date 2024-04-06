using EMS.Contracts.Dictionaries;
using EMS.Shared.RepositoryManagers;

namespace EMS.Shared.Services;

public interface IMedicalExaminationDictService
{
    public Task<IReadOnlyList<DictionaryItemModel>> GetAll();
    public Task<DictionaryItemModel> Add(DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem);
    public Task<DictionaryItemModel?> Delete(Guid id);
}