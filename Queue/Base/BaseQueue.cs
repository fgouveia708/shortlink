using Domain;
using Domain.Contracts;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Queue.Base
{
    public class BaseQueue<T> : IBaseQueue<T> where T : class
    {
        private readonly Configurations _configuration;

        public BaseQueue(IOptions<Configurations> configuration)
        {
            _configuration = configuration.Value;
        }
        public void SendMessage(T message, string queueName)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _configuration.RabbitMqServer,
                    Port = _configuration.RabbitMqPort,
                    UserName = _configuration.RabbitMqUser,
                    Password = _configuration.RabbitMqPassword
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);


                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

                    channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
