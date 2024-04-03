using EMS.Data.Records;
using EMS.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EMS.PersistenceLayer.Repositories;

public class TrainingRepository : BaseRepository<Training>, ITrainingRepository
{
    public TrainingRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }
    
    public override IQueryable<Training> GetAll()
    {
        return base.GetAll().Include(item => item.TrainingItem);
    }

    public IQueryable<Training> GetAll(Guid employeeId)
    {
        return GetAll().Where(item => item.EmployeeId == employeeId);
    }
}