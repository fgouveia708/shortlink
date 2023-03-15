using Amazon.SQS;
using Amazon.SQS.Model;
using Domain.Contracts;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Queue
{
    public class BaseQueue<T> : IBaseQueue<T> where T : class
    {
        private readonly IAmazonSQS _client;

        public BaseQueue(IAmazonSQS client)
        {
            this._client = client;
        }

        public async Task SendMessageAsync(T message, string queueUrl)
        {
            var request = new SendMessageRequest
            {
                QueueUrl = queueUrl,
                MessageBody = JsonConvert.SerializeObject(message)
            };

            try
            {
                var response = await _client.SendMessageAsync(request);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
