using EMS.Data.Records;

namespace EMS.Shared.Repositories;

public interface ITrainingRepository : IBaseRepository<Training>
{
    IQueryable<Training> GetAll(Guid employeeId);
}