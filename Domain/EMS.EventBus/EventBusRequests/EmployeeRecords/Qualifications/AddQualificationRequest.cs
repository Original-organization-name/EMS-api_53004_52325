using EMS.Dto.EmployeeRecords;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

public class AddQualificationRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public QualificationDto Qualification { get; set; } = null!;
    
    public AddQualificationRequest(Guid employeeId, QualificationDto qualification)
    {
        EmployeeId = employeeId;
        Qualification = qualification;
    }

    internal AddQualificationRequest()
    {
    }
}