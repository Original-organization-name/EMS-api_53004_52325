using EMS.Data.Dictionaries;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class OccupationDictRepository : IOccupationDictRepository
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<OccupationCodeItem> _repositoryContext;

    public OccupationDictRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _repositoryContext = dbContext.Set<OccupationCodeItem>();
    }

    public virtual IQueryable<OccupationCodeItem> GetAll()
    {
        return _repositoryContext.AsNoTracking();
    }
}