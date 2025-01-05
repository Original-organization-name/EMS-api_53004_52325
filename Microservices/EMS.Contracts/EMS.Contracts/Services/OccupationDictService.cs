using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Dto.Contracts;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.Services;

public class OccupationDictService(IOccupationDictRepository repository)
    : IOccupationDictService
{
    public async Task<IReadOnlyList<OccupationCodeItemModel>> GetAll()
    {
        return await repository
            .GetAll()
            .Select(item => new OccupationCodeItemModel(item.Code, item.Value))
            .ToListAsync();
    }
}