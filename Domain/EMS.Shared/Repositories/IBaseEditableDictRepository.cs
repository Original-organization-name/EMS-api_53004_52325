using EMS.Shared.Models;

namespace EMS.Shared.Repositories;

public interface IBaseEditableDictRepository<T> : IBaseRepository<T> 
    where T : EditableDictionaryItem
{
    public Task<T?> GetByValueAsync(string value);
    public T? GetByValue(string value);
}