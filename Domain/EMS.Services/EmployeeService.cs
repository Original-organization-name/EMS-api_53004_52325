using EMS.Contracts.Employee;
using EMS.Data.Employee;
using EMS.Shared.Repositories;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;

    public EmployeeService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    
    public async Task<IReadOnlyList<EmployeeModel>> GetAll()
    {
        var employees = _repositoryManager.EmployeeRepository.GetAll();
        return employees.Select(employee => employee.Adapt<EmployeeModel>()).ToList();
    }

    public async Task<EmployeeModel?> GetById(Guid id)
    {
        var employee = await _repositoryManager.EmployeeRepository.GetById(id);
        return employee.Adapt<EmployeeModel>();
    }

    public async Task<EmployeeModel?> Add(EmployeeDto employee)
    {
        var newEmployee = await _repositoryManager.EmployeeRepository.AddAsync(employee.Adapt<Employee>());
        await _repositoryManager.EmployeeRepository.SaveChangesAsync();
        return newEmployee?.Adapt<EmployeeModel>();
    }
}