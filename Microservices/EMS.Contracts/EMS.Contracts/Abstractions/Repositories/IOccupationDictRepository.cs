using EMS.Contracts.Domain.Entities;

namespace EMS.Contracts.Abstractions.Repositories;

public interface IOccupationDictRepository
{
    IQueryable<OccupationCodeItem> GetAll();
}