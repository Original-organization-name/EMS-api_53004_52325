using EMS.Data.Dictionaries;

namespace EMS.Shared.Repositories;

public interface IOccupationDictRepository
{
    IQueryable<OccupationCodeItem> GetAll();
}