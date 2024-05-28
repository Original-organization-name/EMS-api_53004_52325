using EMS.Data.Dictionaries;

namespace EMS.Shared.Services;

public interface IOccupationDictService
{
    Task<IReadOnlyList<OccupationCodeItem>> GetAll();
}