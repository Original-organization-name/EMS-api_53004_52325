using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.MedicalExams;

public class GetEmployeeMedicalExamsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetEmployeeMedicalExamsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal GetEmployeeMedicalExamsRequest()
    {
    }
}