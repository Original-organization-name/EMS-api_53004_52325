namespace EMS.EventBus.Abstractions;

public interface IEventBusRequestHandler<in TRequest, TResponse> : IEventBusRequestHandler
    where TRequest : IEventBusRequest
{
    Task<TResponse> HandleAsync(TRequest @event);
}

public interface IEventBusRequestHandler
{
}