using Crime.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using REP_CRIME._01.Common.Dto;
using System.Text;

namespace Crime.Application.Crime.Messaging.Receive
{
    public class CrimeEventAssignmentResultReceiver : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly ICrimeEventsService _crimeEventsService;
        private readonly IConfiguration _configuration;

        public CrimeEventAssignmentResultReceiver(ICrimeEventsService crimeEventsService, IConfiguration configuration)
        {
            _configuration = configuration;
            CreateConnection();
            _channel.QueueDeclare(queue: "CrimeEventAssignmentQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _crimeEventsService = crimeEventsService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var crimeEvent = JsonConvert.DeserializeObject<AssignmentResult>(content);
                _crimeEventsService.AssignLawEnforcementToCrimeEvent(crimeEvent.CrimeId, crimeEvent.LawEnforcementId);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("CrimeEventAssignmentQueue", autoAck: false, consumer: consumer);
            return Task.CompletedTask;
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
                _channel = _connection.CreateModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Could not create connection: {ex.Message}");
            }
        }
    }
}