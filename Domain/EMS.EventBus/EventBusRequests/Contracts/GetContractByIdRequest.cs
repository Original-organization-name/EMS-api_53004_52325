using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Contracts;

public class GetContractByIdRequest : IEventBusRequest
{
    public Guid Id { get; set; }

    public GetContractByIdRequest(Guid id)
    {
        Id = id;
    }

    internal GetContractByIdRequest()
    {
        
    }
}