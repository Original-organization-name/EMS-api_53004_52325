namespace EMS.EventBus.Abstractions;

public interface IEventBus
{
    Task<TResponse?> RequestAsync<TResponse>(IEventBusRequest request);
}