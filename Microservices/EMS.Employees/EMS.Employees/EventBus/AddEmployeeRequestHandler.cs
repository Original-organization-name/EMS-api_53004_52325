using EMS.Dto.Contracts;
using EMS.Dto.EmployeeRecords;
using EMS.Dto.Employees;
using EMS.Employees.Abstractions.Services;
using EMS.EventBus.Abstractions;
using EMS.EventBus.EventBusRequests.Contracts;
using EMS.EventBus.EventBusRequests.EmployeeRecords;
using EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;
using EMS.EventBus.EventBusRequests.Employees;

namespace EMS.Employees.EventBus;

public class AddEmployeeRequestHandler(IEmployeeService employeeService, IEventBus bus)
    : IEventBusRequestHandler<AddEmployeeRequest, EmployeeModel?>
{
    public async Task<EmployeeModel?> HandleAsync(AddEmployeeRequest request)
    {
        var employee = await employeeService.Add(request.EmployeeModel.Employee);

        if (request.EmployeeModel.MedicalExaminations is not null)
        {
            foreach (var exam in request.EmployeeModel.MedicalExaminations)
            {
                var examRequest = new AddMedicalExaminationRequest(employee.Id, exam);
                await bus.RequestAsync<MedicalExaminationModel>(examRequest);
            }
        }

        if (request.EmployeeModel.Trainings is not null)
        {
            foreach (var training in request.EmployeeModel.Trainings)
            {
                var trainingRequest = new AddTrainingRequest(employee.Id, training);
                await bus.RequestAsync<TrainingModel>(trainingRequest);
            }
        }

        if (request.EmployeeModel.ImageBase64 is not null)
        {
            await employeeService.AddImage(employee.Id, request.EmployeeModel.ImageBase64);
        }
            
        if (request.EmployeeModel.Contract is not null)
        {
            var contractRequest = new AddContractRequest(employee.Id, request.EmployeeModel.Contract);
            await bus.RequestAsync<ContractModel>(contractRequest);
        }

        return employee;
    }
}