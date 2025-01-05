using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Employees;

namespace EMS.Employees.EventBus;

public class GetEmployeeByIdRequestHandler(IEmployeeService employeeService)
    : IEventBusRequestHandler<GetEmployeeByIdRequest, EmployeeModel?>
{
    public async Task<EmployeeModel?> HandleAsync(GetEmployeeByIdRequest request)
    {
        return await employeeService.GetByIdAsync(request.EmployeeId);
    }
}