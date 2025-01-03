using EMS.Shared.Repositories;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Domain.Entities;

namespace EMS.Employees.PersistenceLayer.Repositories;

public class ImageRepository : BaseRepository<EmployeeDbContext, Image>, IImageRepository
{
    public ImageRepository(EmployeeDbContext dbContext) : base(dbContext)
    {
    }

    public Image? GetByName(string name)
    {
        return FindByCondition(x => x.Name == name).FirstOrDefault();
    }
}