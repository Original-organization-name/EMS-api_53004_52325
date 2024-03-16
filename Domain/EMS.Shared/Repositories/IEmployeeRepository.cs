using EMS.Data.Employee;

namespace EMS.Shared.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<Employee?> GetById(Guid id);
    Task<bool> IsPeselExist(string? pesel);
}