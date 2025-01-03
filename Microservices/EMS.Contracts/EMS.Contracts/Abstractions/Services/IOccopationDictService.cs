using EMS.Contracts.Domain.Entities;

namespace EMS.Contracts.Abstractions.Services;

public interface IOccupationDictService
{
    Task<IReadOnlyList<OccupationCodeItem>> GetAll();
}