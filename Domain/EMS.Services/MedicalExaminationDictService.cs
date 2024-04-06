using EMS.Contracts.Dictionaries;
using EMS.Data.Dictionaries;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services;

public class MedicalExaminationDictService : IMedicalExaminationDictService
{
    private readonly IBaseEditableDictRepository<MedicalExamItem> _repository;

    public MedicalExaminationDictService(IDictRepositoryManager repositoryManager) => 
        _repository = repositoryManager.MedicalExamItemRepository;

    public Task<IReadOnlyList<DictionaryItemModel>> GetAll()
    {
        return Task.FromResult<IReadOnlyList<DictionaryItemModel>>(_repository.GetAll().Select(examination => new DictionaryItemModel(examination.Id, examination.Value)).ToList());
    }

    public async Task<DictionaryItemModel> Add(DictionaryItemDto newItem)
    {
        var examination = new MedicalExamItem()
        {
            Value = newItem.Value
        };
        await _repository.AddAsync(examination);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(examination.Id, examination.Value);
    }

    public async Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem)
    {
        var examination = await _repository.GetByIdAsync(id);
        if (examination is null)
        {
            return null;
        }

        examination.Value = newItem.Value;
        
        await _repository.UpdateAsync(examination);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(examination.Id, examination.Value);
    }

    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var examination = await _repository.GetByIdAsync(id);
        if (examination is null)
        {
            return null;
        }
        
        await _repository.DeleteAsync(examination);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(examination.Id, examination.Value);
    }
}