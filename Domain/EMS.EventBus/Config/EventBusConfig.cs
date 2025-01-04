using RabbitMQ.Client;

namespace EMS.EventBus.Config;

public static class EventBusConfig
{
    public static ConnectionFactory ConnectionFactory = new()
    { 
        HostName = "rabbitmq",   
        UserName = "admin",
        Password = "admin"
    };
}