using EMS.Contracts.Abstractions.Repositories;
using EMS.Contracts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Contracts.PersistenceLayer.Repositories;

public class OccupationDictRepository(ContractsDbContext dbContext) 
    : IOccupationDictRepository
{
    private readonly DbSet<OccupationCodeItem> _repositoryContext = dbContext.Set<OccupationCodeItem>();

    public virtual IQueryable<OccupationCodeItem> GetAll()
    {
        return _repositoryContext.AsNoTracking();
    }
}