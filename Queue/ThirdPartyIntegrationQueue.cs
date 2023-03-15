using Domain;
using Domain.Contracts;
using Domain.Messages;
using Microsoft.Extensions.Options;
using System;

namespace Queue
{
    public class ThirdPartyIntegrationQueue : IThirdPartyIntegrationQueue
    {
        private readonly IBaseQueue<ThirdPartyIntegration> _context;
        private readonly Configurations _configuration;
        public string QueueName
        {
            get
            {
                return _configuration.ThirdPartyQueue;
            }
        }
        public ThirdPartyIntegrationQueue(IBaseQueue<ThirdPartyIntegration> context,
            IOptions<Configurations> configuration)
        {
            _context = context;
            _configuration = configuration.Value;
        }

        public void SendMessage(ThirdPartyIntegration message)
        {
            _context.SendMessage(message, this.QueueName);
        }
    }
}
