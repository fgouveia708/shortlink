using Domain.Messages;

namespace Domain.Contracts
{
    public interface IThirdPartyIntegrationQueue
    {
        void SendMessageAsync(ThirdPartyIntegration message);
    }
}
