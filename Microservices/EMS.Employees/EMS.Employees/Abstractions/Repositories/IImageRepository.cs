using EMS.Shared.Repositories;
using EMS.Employees.Domain.Entities;

namespace EMS.Employees.Abstractions.Repositories;

public interface IImageRepository : IBaseRepository<Image>
{
    Image? GetByName(string name);
}