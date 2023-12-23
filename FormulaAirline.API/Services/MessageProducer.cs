using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace FormulaAirline.API.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            
            // Ensure the queue is not exclusive unless it needs to be
            channel.QueueDeclare(queue: "bookings", durable: true, exclusive: false, autoDelete: false, arguments: null);
            
            var jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);

            channel.BasicPublish(exchange: "", routingKey: "bookings", basicProperties: null, body: body);
        }
    }
}
