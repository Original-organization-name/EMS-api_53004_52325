using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.EmployeeRecords.Qualifications;

public class GetQualificationByIdRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public GetQualificationByIdRequest(Guid id)
    {
        Id = id;
    }

    internal GetQualificationByIdRequest()
    {
    }
}