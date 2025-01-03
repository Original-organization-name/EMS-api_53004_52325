using EMS.Domain.Abstractions;
using EMS.Domain.Abstractions.Dictionaries;
using EMS.Domain.Models;
using EMS.Domain.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.Domain.Services;

public class BaseEditableDictService<T>(IBaseEditableDictRepository<T> repository)
    : IBaseEditableDictService<T>
    where T : EditableDictionaryItem
{
    public async Task<IReadOnlyList<DictionaryItemModel>> GetAllAsync()
    {
        return await repository
            .GetAll()
            .Select(item => 
                new DictionaryItemModel(item.Id, item.Value))
            .ToListAsync();
    }

    public async Task<DictionaryItemModel> Add(DictionaryItemDto newItem)
    {
        var item = newItem.Adapt<T>();
        
        await repository.AddAsync(item);
        await repository.SaveChangesAsync();

        return new DictionaryItemModel(item.Id, item.Value);
    }

    public async Task<DictionaryItemModel?> Update(Guid id, DictionaryItemDto newItem)
    {
        var training = await repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }

        training.Value = newItem.Value;
        
        await repository.UpdateAsync(training);
        await repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }

    public async Task<DictionaryItemModel?> Delete(Guid id)
    {
        var training = await repository.GetByIdAsync(id);
        if (training is null)
        {
            return null;
        }
        
        await repository.DeleteAsync(training);
        await repository.SaveChangesAsync();

        return new DictionaryItemModel(training.Id, training.Value);
    }
}