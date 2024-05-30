using EMS.Data.Employees.Entities;

namespace EMS.Shared.Repositories;

public interface IImageRepository : IBaseRepository<Image>
{
    Image? GetByName(string name);
}