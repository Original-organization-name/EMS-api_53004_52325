using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Education;

public class GetEducationByIdRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public GetEducationByIdRequest(Guid id)
    {
        Id = id;
    }

    internal GetEducationByIdRequest()
    {
        
    }
}