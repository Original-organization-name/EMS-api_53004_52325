using EMS.Data.Models;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class BaseEditableDictRepository<T> : BaseRepository<T>, IBaseEditableDictRepository<T> 
    where T : EditableDictionaryItem
{
    public BaseEditableDictRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public async Task<T?> GetByValueAsync(string value)
    {
        return await GetAll().FirstOrDefaultAsync(x => string.Equals(x.Value, value));
    }
    
    public T? GetByValue(string value)
    {
        return GetAll().FirstOrDefault(x => string.Equals(x.Value, value));
    }
    
    public new async Task<T?> AddAsync(T entity)
    {
        var item = await GetByValueAsync(entity.Value);
        if (item == null) return await base.AddAsync(entity);
        
        entity = item;
        return entity;

    }
    
    public new T? Add(T entity)
    {
        var item =  GetByValue(entity.Value);
        if (item == null) return base.Add(entity);
        
        entity = item;
        return entity;

    }
}