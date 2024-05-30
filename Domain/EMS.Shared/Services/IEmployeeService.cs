using System.Linq.Expressions;
using EMS.Data.Employees;
using EMS.DTO.Employee;

namespace EMS.Shared.Services;

public interface IEmployeeService
{
    Task<IReadOnlyList<EmployeeModel>> GetAll();
    Task<IEnumerable<EmployeeModel>> GetRecentAdded();
    Task<EmployeeModel?> GetById(Guid id);
    Task<EmployeeModel> Add(EmployeeDto employee);
    
    int Count();
    int Count(Expression<Func<Employee, bool>> expression);

    Task<string?> AddImage(Guid employeeId, string imageBase64);
}