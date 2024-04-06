using EMS.Contracts.Dictionaries;
using EMS.Data.Models;
using EMS.Shared.Repositories;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services.Dictionaries;

public class BaseEditableDictService<T> : IBaseEditableDictService<T>
    where T : EditableDictionaryItem
{
    protected readonly IBaseEditableDictRepository<T> Repository;

    public BaseEditableDictService(IBaseEditableDictRepository<T> repository) => 
        Repository = repository;
    
    public async Task<IReadOnlyList<DictionaryItemModel>> GetAll()
    {
        return Repository.GetAll().Select(item => new DictionaryItemModel(item.Id, item.Value)).ToList();
    }

    public async Task<DictionaryItemModel> Add(DictionaryItemDto newItem)
    {
        var item = newItem.Adapt<T>();
        
        await Repository.AddAsync(item);
        await Repository.SaveChangesAsync();

        return new DictionaryItemModel(item.Id, item.Value);
    }

    public async Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem)
    {
        var training = await Repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }

        training.Value = newItem.Value;
        
        await Repository.UpdateAsync(training);
        await Repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }

    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var training = await Repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }
        
        await Repository.DeleteAsync(training);
        await Repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }
}