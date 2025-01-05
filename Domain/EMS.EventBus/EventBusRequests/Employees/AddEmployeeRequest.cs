using EMS.Dto.Employees;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Employees;

public class AddEmployeeRequest : IEventBusRequest
{
    public CreateEmployeeModel EmployeeModel { get; set; } = null!;

    public AddEmployeeRequest(CreateEmployeeModel employeeModel)
    {
        EmployeeModel = employeeModel;
    }
    
    internal AddEmployeeRequest()
    {
        
    }
}