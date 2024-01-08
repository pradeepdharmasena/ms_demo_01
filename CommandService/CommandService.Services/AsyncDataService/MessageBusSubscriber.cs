using CommandService.Services.EventProcessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Services.AsyncDataService
{
    public class MessageBusSubscriber : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly IEventProcessing _eventProcessing;
        private IConnection _connection;
        private IModel _chnnel;
        private string _queueName;

        public MessageBusSubscriber(IConfiguration configuration, IEventProcessing eventProcessing)
        {
            _configuration = configuration;
            _eventProcessing = eventProcessing;
            IntializeRabbitMQ();
        }

        private void IntializeRabbitMQ()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName =  _configuration["RabbitmqHost"],
                Port = int.Parse(_configuration["RabbitmqPort"])

            };
            _connection = connectionFactory.CreateConnection();
            _chnnel = _connection.CreateModel();
            _chnnel.ExchangeDeclare(
                exchange: "trigger",
                type : ExchangeType.Fanout
                );
            _queueName = _chnnel.QueueDeclare().QueueName;
            _chnnel.QueueBind(
                queue : _queueName,
                exchange : "trigger",
                routingKey : ""
                );
            Console.WriteLine("Listening on Message Bus");
            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            var consumer = new EventingBasicConsumer(_chnnel);

            consumer.Received += (ModuleHandle, ea) =>
            {
                Console.WriteLine("Event Recieved");
                var body = ea.Body;
                var notificationMessage = Encoding.UTF8.GetString(body.ToArray());
                _eventProcessing.ProcessEvent(notificationMessage);
            };

            _chnnel.BasicConsume(queue: _queueName, autoAck:true, consumer: consumer);

            return Task.CompletedTask;
        }

        private void RabbitMQ_ConnectionShutdown(object sender , ShutdownEventArgs shutdownEventArgs)
        {
            Console.WriteLine("--> Connection Shutdown....");
        }

        public override void Dispose() 
        {
            if(_chnnel.IsOpen) 
            {
                _chnnel.Close();
                _connection.Close();
            }
            base.Dispose();

        }
    }
}
