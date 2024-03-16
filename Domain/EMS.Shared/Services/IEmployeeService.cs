using EMS.Contracts.Employee;

namespace EMS.Shared.Services;

public interface IEmployeeService
{
    Task<IReadOnlyList<EmployeeModel>> GetAll();
    Task<EmployeeModel?> GetById(Guid id);
    Task<EmployeeModel> Add(EmployeeDto employee);
}