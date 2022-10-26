using Crime.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using REP_CRIME._01.Common.Dto;
using System.Text;

namespace Crime.Application.Crime.Messaging_Send
{
    internal class CrimeEventSender : ICrimeEventSender
    {
        private IConnection _connection;
        private readonly IConfiguration _configuration;

        public CrimeEventSender(IConfiguration configuration)
        {
            CreateConnection();
            _configuration = configuration;
        }

        public void SendCrimeEvent(CrimeEventDto data)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CrimeEventQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "", routingKey: "CrimeEventQueue", basicProperties: null, body: body);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "rabbitmq"
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }
    }
}