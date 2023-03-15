using Domain.Contracts;
using Domain.Messages;
using System;
using System.Threading.Tasks;

namespace Queue
{
    public class ThirdPartyIntegrationQueue : IThirdPartyIntegrationQueue
    {
        private readonly IBaseQueue<ThirdPartyIntegration> _context;

        public string QueueUrl
        {
            get
            {
                return string.Concat(Environment.GetEnvironmentVariable("SqsQueueUrl"), Environment.GetEnvironmentVariable("SqsThirdPartyQueue"));
            }
        }
        public ThirdPartyIntegrationQueue(IBaseQueue<ThirdPartyIntegration> context)
        {
            _context = context;
        }

        public async Task SendMessageAsync(ThirdPartyIntegration message)
        {
            await _context.SendMessageAsync(message, this.QueueUrl);
        }
    }
}
