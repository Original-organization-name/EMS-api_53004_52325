using EMS.Domain.Repositories;
using EMS.Employees.Domain;

namespace EMS.Employees.Abstractions.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<bool> IsPeselExist(string? pesel);
}