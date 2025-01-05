using EMS.EventBus.Abstractions;

namespace EMS.EventBus.EventBusRequests.Employees;

public class GetImageRequest : IEventBusRequest
{
    public string ImageName { get; set; } = null!;
    
    public GetImageRequest(string imageName)
    {
        ImageName = imageName;
    }

    internal GetImageRequest()
    {
        
    }
}