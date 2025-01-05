using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

public class DeleteEmployeeMedicalExamsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    
    public DeleteEmployeeMedicalExamsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal DeleteEmployeeMedicalExamsRequest()
    {
    }
}