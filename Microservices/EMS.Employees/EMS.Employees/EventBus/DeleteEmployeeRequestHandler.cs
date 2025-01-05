using EMS.Dto.Contracts;
using EMS.Dto.EmployeeRecords;
using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;
using EMS.EventBus.EventBusRequests.EmployeeRecords.Trainings;
using EMS.EventBus.EventBusRequests.Employees;

namespace EMS.Employees.EventBus;

public class DeleteEmployeeRequestHandler(IEmployeeService employeeService, IEventBus bus)
    : IEventBusRequestHandler<DeleteEmployeeRequest, EmployeeModel?>
{
    public async Task<EmployeeModel?> HandleAsync(DeleteEmployeeRequest request)
    {
        var employee = await employeeService.DeleteAsync(request.EmployeeId);

        if (employee is null)
        {
            return null;
        }
        
        var examRequest = new DeleteEmployeeMedicalExamsRequest(request.EmployeeId);
        await bus.RequestAsync<IEnumerable<MedicalExaminationModel>>(examRequest);

        var trainingRequest = new DeleteEmployeeTrainingsRequest(employee.Id);
        await bus.RequestAsync<IEnumerable<TrainingModel>>(trainingRequest);

        var contractRequest = new DeleteEmployeeContractsRequest(employee.Id);
        await bus.RequestAsync<IEnumerable<ContractModel>>(contractRequest);

        return employee;
    }
}