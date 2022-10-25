using LawEnforcement.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using REP_CRIME._01.Common.Dto;
using System.Text;

namespace LawEnforcement.Application.LawEnforcement.Messaging.Receive
{
    public class CrimeEventReceiver : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private readonly ILawEnforcementTeamService _lawEnforcementService;
        private readonly IConfiguration _configuration;

        public CrimeEventReceiver(IServiceScopeFactory scopeFactory, ILawEnforcementTeamService lawEnforcementService, IConfiguration configuration)
        {
            CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "CrimeEventQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            _lawEnforcementService = lawEnforcementService;
            _configuration = configuration;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var crimeEvent = JsonConvert.DeserializeObject<CrimeEventDto>(content);
                _lawEnforcementService.AssignCrimeEventToEnforcementTeamAsync(crimeEvent.EventId);
                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("CrimeEventQueue", autoAck: false, consumer: consumer);
            return Task.CompletedTask;
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
    }
}