using EMS.Dto.Contracts;

namespace EMS.Contracts.Abstractions.Services;

public interface IOccupationDictService
{
    Task<IReadOnlyList<OccupationCodeItemModel>> GetAll();
}