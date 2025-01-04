using System.Reflection;
using EMS.EventBus.Abstractions;
using EMS.EventBus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.EventBus.Extensions;

public static class WebBuilderExtensions
{
    public static IServiceCollection AddEventBus(this IServiceCollection services)
    {
        var requestHandlerType = typeof(IEventBusRequestHandler);

        foreach (var handler in Assembly.GetCallingAssembly()
                     .GetTypes()
                     .Where(type => requestHandlerType.IsAssignableFrom(type) && !type.IsInterface))
        {
            services.AddTransient(handler);
        }
        
        services.AddHostedService<RabbitMqConsumerService>();
        return services;
    }
}