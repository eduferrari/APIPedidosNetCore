using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace APIPedidosNetCore.Infrastructure.Services;

public class RabbitMQService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public RabbitMQService()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "order_queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void SendMessage<T>(T message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        _channel.BasicPublish(exchange: "",
            routingKey: "order_queue",
            basicProperties: null,
            body: body);
    }
}