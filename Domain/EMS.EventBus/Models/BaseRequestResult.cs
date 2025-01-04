using System.Text.Json;

namespace EMS.EventBus.Models;

public class BaseRequestResult
{
    public string? SerializedResult { get; set; }

    public BusStatusCode Status { get; set; } = BusStatusCode.Success;

    public string? ExceptionMassage { get; set; }

    public BaseRequestResult(object? result)
    {
        SerializedResult = JsonSerializer.Serialize(result);
    }

    public BaseRequestResult(BusStatusCode status, Exception exception)
    {
        Status = status;
        ExceptionMassage = exception.ToString();
    }

    public BaseRequestResult()
    {
        
    }
}