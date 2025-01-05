using System.Linq.Expressions;
using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Repositories;
using EMS.Employees.Abstractions.Services;
using EMS.Employees.Domain;
using EMS.Employees.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EMS.Employees.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IImageRepository imageRepository) : IEmployeeService
{
    public async Task<IReadOnlyList<EmployeeModel>> GetAllAsync()
    {
        var employees = employeeRepository.GetAll();
        return await employees
            .Select(employee => employee.Adapt<EmployeeModel>())
            .ToListAsync();
    }

    public async Task<IEnumerable<EmployeeModel>> GetRecentAddedAsync()
    {
        var employees = await employeeRepository
            .FindByCondition(x => x.CreatedAt.AddDays(14) >= DateTime.Today)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
        
        return employees?
            .Select(employee => employee.Adapt<EmployeeModel>())
            .ToList() ?? new List<EmployeeModel>();
    }

    public async Task<EmployeeModel?> GetByIdAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);
        return employee.Adapt<EmployeeModel>();
    }

    public async Task<EmployeeModel> Add(EmployeeDto employee)
    {
        var newEmployee = await employeeRepository.AddAsync(employee.Adapt<Employee>());
        await employeeRepository.SaveChangesAsync();
        return newEmployee.Adapt<EmployeeModel>();
    }

    public int Count()
    {
        return employeeRepository.GetAll().Count();
    }

    public int Count(Expression<Func<Employee, bool>> expression)
    {
        return employeeRepository.FindByCondition(expression).Count();
    }

    public async Task<string?> AddImage(Guid employeeId, string imageBase64)
    {
        var employee = employeeRepository.FindByConditionWithTracking(x => x.Id == employeeId).FirstOrDefault();
        if (employee is null) return null;
        
        var image = Image.FromBase64String(imageBase64);
        if (image is null) return null;
        
        employee.ImageFileName = image.Name;
        await imageRepository.AddAsync(image);
        await imageRepository.SaveChangesAsync();
        await employeeRepository.SaveChangesAsync();

        return image.Name;
    }

    public async Task<EmployeeModel?> DeleteAsync(Guid id)
    {
        var employee = await employeeRepository.GetByIdAsync(id);
        await employeeRepository.DeleteAsync(employee);
        await employeeRepository.SaveChangesAsync();

        return employee?.Adapt<EmployeeModel>();
    }
}