using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using REP_CRIME._01.Common.Dto;
using System.Text;

namespace LawEnforcement.Application.LawEnforcement.Messaging.Send
{
    public class CrimeEventAssignmentResultSender : ICrimeEventAssignmentResultSender
    {
        private IConnection _connection;
        private readonly IConfiguration _configuration;

        public CrimeEventAssignmentResultSender(IConfiguration configuration)
        {
            CreateConnection();
            _configuration = configuration;
        }

        public void SendCrimeEventAssignmentResult(AssignmentResult result)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "CrimeEventAssignmentQueue",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                    var body = Encoding.UTF8.GetBytes(json);
                    channel.BasicPublish(exchange: "", routingKey: "CrimeEventAssignmentQueue", basicProperties: null, body: body);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "rabbitmq-repcrime"
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