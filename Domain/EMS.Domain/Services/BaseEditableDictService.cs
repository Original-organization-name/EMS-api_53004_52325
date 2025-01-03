using EMS.Domain.Abstractions;
using EMS.Domain.Abstractions.Dictionaries;
using EMS.Domain.Models;
using EMS.Domain.Repositories;
using Mapster;

namespace EMS.Domain.Services;

public class BaseEditableDictService<T>(IBaseEditableDictRepository<T> repository)
    : IBaseEditableDictService<T>
    where T : EditableDictionaryItem
{
    protected readonly IBaseEditableDictRepository<T> Repository = repository;

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