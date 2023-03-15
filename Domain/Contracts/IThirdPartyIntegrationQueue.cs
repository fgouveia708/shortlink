using Domain.Messages;

namespace Domain.Contracts
{
    public interface IThirdPartyIntegrationQueue 
    {
        void SendMessage(ThirdPartyIntegration message);
    }
}
