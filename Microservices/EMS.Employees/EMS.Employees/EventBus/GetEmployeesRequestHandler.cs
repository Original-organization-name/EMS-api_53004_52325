using EMS.Dto.Contracts;
using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;
using EMS.EventBus.EventBusRequests.EmployeeRecords;
using EMS.EventBus.EventBusRequests.Employees;
using EMS.Shared.Shared;

namespace EMS.Employees.EventBus;

public class GetEmployeesRequestHandler(IEmployeeService employeeService, IEventBus bus)
    : IEventBusRequestHandler<GetEmployeesRequest, IEnumerable<EmployeeTableInfo>>
{
    public async Task<IEnumerable<EmployeeTableInfo>> HandleAsync(GetEmployeesRequest request)
    {
        var employees = await employeeService.GetAllAsync();
        var result = new List<EmployeeTableInfo>();
        
        foreach (var employee in employees)
        {
            var contract = await bus.RequestAsync<ContractModel>(new GetCurrentOrLatestContractRequest(employee.Id));
            var bhpStatus = await bus.RequestAsync<RecordStatus>(new GetBhpStatusRequest(employee.Id));
            result.Add(new EmployeeTableInfo()
            {
                Id = employee.Id,
                Name = employee.Name, 
                Surname = employee.Surname,
                Pesel = employee.Pesel,
                ImageName = employee.ImageFileName,
                Position = contract?.PositionItemName,
                Workplace = contract?.WorkplaceItemName,
                ContractType = contract?.ContractType,
                EmploymentDate = contract?.EmploymentDate,
                TerminationDate = contract?.TerminationDate,
                Salary = contract?.Salary, 
                SalaryType = contract?.SalaryType,
                FteDenominator = contract?.FteDenominator,
                FteNumerator = contract?.FteNumerator,
                ContractStartDate = contract?.StartDate,
                BhpStatus = bhpStatus,
            });
        }

        return result;
    }
}