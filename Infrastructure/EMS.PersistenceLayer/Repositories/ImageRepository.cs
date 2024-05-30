using EMS.Data.Employees.Entities;
using EMS.Shared.Repositories;

namespace EMS.PersistenceLayer.Repositories;

public class ImageRepository : BaseRepository<Image>, IImageRepository
{
    public ImageRepository(DatabaseContext dbContext) : base(dbContext)
    {
    }

    public Image? GetByName(string name)
    {
        return FindByCondition(x => x.Name == name).FirstOrDefault();
    }
}