namespace EMS.EventBus.Abstractions;

public interface IEventBusRequestHandler<TRequest, TResponse> : IEventBusRequestHandler
    where TRequest : IEventBusRequest
{
    Task<TResponse> HandleAsync(TRequest @event);
}

public interface IEventBusRequestHandler
{
}