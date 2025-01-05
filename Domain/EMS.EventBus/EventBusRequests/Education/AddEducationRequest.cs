using EMS.Dto.Education;
using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Education;

public class AddEducationRequest : IEventBusRequest
{
    public Guid EmployeeId { get; set; }

    public EducationDto Education { get; set; } = null!;

    public AddEducationRequest(Guid employeeId, EducationDto education)
    {
        EmployeeId = employeeId;
        Education = education;
    }

    internal AddEducationRequest()
    {
        
    }
}