using EMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EMS.Shared.Repositories;

public class BaseEditableDictRepository<TContext, TItem> : BaseRepository<TContext, TItem>, IBaseEditableDictRepository<TItem> 
    where TItem : EditableDictionaryItem
    where TContext : DbContext
{
    public BaseEditableDictRepository(TContext dbContext) : base(dbContext)
    {
    }

    public async Task<TItem?> GetByValueAsync(string value)
    {
        return await GetAll().FirstOrDefaultAsync(x => string.Equals(x.Value, value));
    }
    
    public TItem? GetByValue(string value)
    {
        return GetAll().FirstOrDefault(x => string.Equals(x.Value, value));
    }
    
    public new async Task<TItem?> AddAsync(TItem entity)
    {
        var item = await GetByValueAsync(entity.Value);
        if (item == null) return await base.AddAsync(entity);
        
        entity = item;
        return entity;
    }
    
    public new TItem? Add(TItem entity)
    {
        var item =  GetByValue(entity.Value);
        if (item == null) return base.Add(entity);
        
        entity = item;
        return entity;

    }
}