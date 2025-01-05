using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

public class GetEmployeeQualificationsRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public GetEmployeeQualificationsRequest(Guid employeeId)
    {
        EmployeeId = employeeId;
    }

    internal GetEmployeeQualificationsRequest()
    {
    }
}