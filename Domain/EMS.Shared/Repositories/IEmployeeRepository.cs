using EMS.Data.Employees;

namespace EMS.Shared.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<bool> IsPeselExist(string? pesel);
}