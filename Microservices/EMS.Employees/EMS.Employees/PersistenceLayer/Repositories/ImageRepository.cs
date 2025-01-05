using EMS.Shared.Repositories;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Employees.PersistenceLayer.Repositories;

public class ImageRepository : BaseRepository<EmployeeDbContext, Image>, IImageRepository
{
    public ImageRepository(EmployeeDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Image?> GetByNameAsync(string name)
    {
        return await FindByCondition(x => x.Name == name).FirstOrDefaultAsync();
    }
}