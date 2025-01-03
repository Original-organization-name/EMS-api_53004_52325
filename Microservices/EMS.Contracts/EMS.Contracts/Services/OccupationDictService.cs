using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Abstractions.Services;
using EMS.Contracts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.Services;

public class OccupationDictService(IOccupationDictRepository repository)
    : IOccupationDictService
{
    public async Task<IReadOnlyList<OccupationCodeItem>> GetAll()
    {
        return await repository.GetAll().ToListAsync();
    }
}