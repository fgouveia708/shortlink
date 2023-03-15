using Domain.Contracts;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Queue
{
    public class BaseQueue<T> : IBaseQueue<T> where T : class
    {

        public void SendMessage(T message, string queueName)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "admin",
                    Password = "admin"
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
