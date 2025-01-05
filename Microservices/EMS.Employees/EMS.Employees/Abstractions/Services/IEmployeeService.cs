using System.Linq.Expressions;
using EMS.Dto.Employees;
using EMS.Employees.Domain;

namespace EMS.Employees.Abstractions.Services;

public interface IEmployeeService
{
    Task<IReadOnlyList<EmployeeModel>> GetAllAsync();
    Task<IEnumerable<EmployeeModel>> GetRecentAddedAsync();
    Task<EmployeeModel?> GetByIdAsync(Guid id);
    Task<EmployeeModel> Add(EmployeeDto employee);
    
    int Count();
    int Count(Expression<Func<Employee, bool>> expression);

    Task<string?> AddImage(Guid employeeId, string imageBase64);

    Task<EmployeeModel?> DeleteAsync(Guid id);
}