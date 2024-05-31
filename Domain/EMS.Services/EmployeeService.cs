using System.Linq.Expressions;
using EMS.DTO.Employee;
using EMS.Data.Employees;
using EMS.Data.Employees.Entities;
using EMS.Data.Exceptions;
using EMS.Shared.Repositories;
using EMS.Shared.RepositoryManagers;
using EMS.Shared.Services;
using Mapster;

namespace EMS.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IImageRepository _imageRepository;

    public EmployeeService(IRepositoryManager repositoryManager)
    {
        _employeeRepository = repositoryManager.EmployeeRepository;
        _imageRepository = repositoryManager.ImageRepository;
    }

    public async Task<IReadOnlyList<EmployeeModel>> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        return employees.Select(employee => employee.Adapt<EmployeeModel>()).ToList();
    }

    public async Task<IEnumerable<EmployeeModel>> GetRecentAdded()
    {
        var employees = _employeeRepository
            .FindByCondition(x => x.CreatedAt.AddDays(14) >= DateTime.Today)
            .OrderByDescending(x => x.CreatedAt)
            .ToList();
        return employees?.Select(employee => employee.Adapt<EmployeeModel>()).ToList() ?? new List<EmployeeModel>();
    }

    public async Task<EmployeeModel?> GetById(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return employee.Adapt<EmployeeModel>();
    }

    public async Task<EmployeeModel> Add(EmployeeDto employee)
    {
        var newEmployee = await _employeeRepository.AddAsync(employee.Adapt<Employee>());
        await _employeeRepository.SaveChangesAsync();
        return newEmployee.Adapt<EmployeeModel>();
    }

    public int Count()
    {
        return _employeeRepository.GetAll().Count();
    }

    public int Count(Expression<Func<Employee, bool>> expression)
    {
        return _employeeRepository.FindByCondition(expression).Count();
    }

    public async Task<string?> AddImage(Guid employeeId, string imageBase64)
    {
        var employee = _employeeRepository.FindByConditionWithTracking(x => x.Id == employeeId).FirstOrDefault();
        if (employee is null) return null;
        
        var image = Image.FromBase64String(imageBase64);
        if (image is null) return null;
        
        employee.ImageFileName = image.Name;
        await _imageRepository.AddAsync(image);
        await _imageRepository.SaveChangesAsync();
        await _employeeRepository.SaveChangesAsync();

        return image.Name;
    }

    public async Task<EmployeeModel?> Delete(Guid id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        await _employeeRepository.DeleteAsync(employee);
        await _employeeRepository.SaveChangesAsync();

        return employee?.Adapt<EmployeeModel>();
    }
}