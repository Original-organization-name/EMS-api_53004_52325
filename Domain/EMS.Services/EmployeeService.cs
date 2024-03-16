using EMS.Contracts.Employee;
using EMS.Data.Employee;
using EMS.Shared.Repositories;
using EMS.Shared.Services;

namespace EMS.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IRepositoryManager _repositoryManager;

    public EmployeeService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;
    
    public async Task<IReadOnlyList<EmployeeModel>> GetAll()
    {
        var employees = _repositoryManager.EmployeeRepository.GetAll();

        return employees.Select(employee => 
            new EmployeeModel(
                employee.Id,
                employee.Name,
                employee.Surname,
                employee.Pesel,
                employee.Nip,
                employee.Birthdate,
                employee.Gender,
                employee.Address == null ? null : new AddressDto(
                    employee.Address.CountryCode,
                    employee.Address.City,
                    employee.Address.District,
                    employee.Address.PostCode,
                    employee.Address.Street,
                    employee.Address.HouseNumber,
                    employee.Address.ApartmentNumber),
                employee.Contacts.Select(contract => new ContactModel(
                    contract.Id,
                    contract.Type,
                    contract.Data,
                    contract.Privacy
                    )).ToList(),
                employee.PaymentMethod == null ? null : new PaymentMethodDto(
                    employee.PaymentMethod.Type,
                    employee.PaymentMethod.BankAccount)
                )).ToList();
    }

    public Task<EmployeeModel> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeModel?> Add(EmployeeDto employee)
    {
        var newEmployee = await _repositoryManager.EmployeeRepository.AddAsync(
            new Employee()
            {
                Name = employee.Name,
                Surname = employee.Surname,
            });

        await _repositoryManager.EmployeeRepository.SaveChangesAsync();

        return newEmployee is null ? null : new EmployeeModel(
            newEmployee.Id,
            newEmployee.Name,
            newEmployee.Surname,
            newEmployee.Pesel,
            newEmployee.Nip,
            newEmployee.Birthdate,
            newEmployee.Gender,
            newEmployee.Address == null
                ? null
                : new AddressDto(
                    newEmployee.Address.CountryCode,
                    newEmployee.Address.City,
                    newEmployee.Address.District,
                    newEmployee.Address.PostCode,
                    newEmployee.Address.Street,
                    newEmployee.Address.HouseNumber,
                    newEmployee.Address.ApartmentNumber),
            newEmployee.Contacts.Select(contract => new ContactModel(
                contract.Id,
                contract.Type,
                contract.Data,
                contract.Privacy
            )).ToList(),
            newEmployee.PaymentMethod == null
                ? null
                : new PaymentMethodDto(
                    newEmployee.PaymentMethod.Type,
                    newEmployee.PaymentMethod.BankAccount)
        );
    }
}