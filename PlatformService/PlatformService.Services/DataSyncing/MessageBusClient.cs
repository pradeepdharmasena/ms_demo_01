using Microsoft.Extensions.Configuration;
using PlatformService.Services.Dtos;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.Services.DataSyncing
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration config) 
        {
            _config = config;
            var factory = new ConnectionFactory() { 
                HostName = _config["RabbitmqHost"],
                Port = int.Parse(_config["RabbitmqPort"])
            };
            try 
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
                Console.WriteLine("--> rabbitmq connection started....");
            }
            catch(Exception ex)
            {
                Console.WriteLine("--> rabbitmq connection Error : " + ex.Message);
            }
        }
        public void PublishNewPlatform(PlatformReadDto platformReadDto)
        {
           var message = JsonSerializer.Serialize(platformReadDto);
        if(_connection.IsOpen) 
            {
                Console.WriteLine("connection is open");
                SendMessage(message);
            }
        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger",
                        routingKey:"",
                        basicProperties:null,
                        body:body);
            Console.WriteLine("Sending message");
        }

        private void Dispose() 
        {
            Console.WriteLine("Message bus Dispose");
            if(_channel.IsOpen) 
            {
                _channel.Close();
                _connection.Close();
            }
        }

        private void RabbitMQ_ConnectionShutdown(object sender, EventArgs e)
        {
            Console.WriteLine("--> rabbitmq connection shutdown....");
        }
    }
}
