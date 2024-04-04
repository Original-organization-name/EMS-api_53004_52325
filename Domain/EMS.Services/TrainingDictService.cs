using EMS.Contracts.Dictionaries;
using EMS.Data.Dictionaries;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;

namespace EMS.Services;

public class TrainingDictService : ITrainingDictService
{
    private readonly IBaseEditableDictRepository<TrainingItem> _repository;

    public TrainingDictService(IDictRepositoryManager repositoryManager) => 
        _repository = repositoryManager.TrainingItemRepository;

    
    public async Task<IReadOnlyList<DictionaryItemModel>> GetAll()
    {
        return _repository.GetAll().Select(training => new DictionaryItemModel(training.Id, training.Value)).ToList();
    }

    public async Task<DictionaryItemModel> Add(DictionaryItemDto newItem)
    {
        var training = new TrainingItem()
        {
            Value = newItem.Value
        };

        await _repository.AddAsync(training);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }

    public async Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem)
    {
        var training = await _repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }

        training.Value = newItem.Value;
        
        await _repository.UpdateAsync(training);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }

    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var training = await _repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }
        
        await _repository.DeleteAsync(training);
        await _repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }
}