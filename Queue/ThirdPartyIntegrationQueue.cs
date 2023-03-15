using Domain.Contracts;
using Domain.Messages;
using System;

namespace Queue
{
    public class ThirdPartyIntegrationQueue : IThirdPartyIntegrationQueue
    {
        private readonly IBaseQueue<ThirdPartyIntegration> _context;

        public string QueueName
        {
            get
            {
                return Environment.GetEnvironmentVariable("SqsThirdPartyQueue");
            }
        }
        public ThirdPartyIntegrationQueue(IBaseQueue<ThirdPartyIntegration> context)
        {
            _context = context;
        }

        public void SendMessageAsync(ThirdPartyIntegration message)
        {
            _context.SendMessage(message, this.QueueName);
        }
    }
}
