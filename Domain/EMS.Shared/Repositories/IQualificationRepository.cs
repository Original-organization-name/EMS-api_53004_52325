using EMS.Data.Records;

namespace EMS.Shared.Repositories;

public interface IQualificationRepository : IBaseRepository<Qualification>
{
    IQueryable<Qualification> GetAll(Guid employeeId);
}