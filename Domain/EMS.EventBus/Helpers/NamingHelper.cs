using EMS.EventBus.Abstractions;

namespace EMS.EventBus.Helpers;

public static class NamingHelper
{
    public static string GetQueueName<TRequest>(this TRequest request) 
        where TRequest : IEventBusRequest
    {
        return GetQueueName(typeof(TRequest));
    }
    
    public static string GetQueueName(this Type requestType) 
    {
        return requestType.Name.Replace("Request", "").ToLower() + "_queue";
    }
}