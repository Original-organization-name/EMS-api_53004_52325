using EMS.Data.Models;

namespace EMS.Shared.Services;

public interface IEditableDictionaryService<TEntity>
    where TEntity : EditableDictionaryItem
{
    Task<IReadOnlyDictionary<Guid, string>> GetAll();
    Task<string?> GetById(Guid id);
}
