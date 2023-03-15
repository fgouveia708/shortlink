using Domain.Messages;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IThirdPartyIntegrationQueue
    {
        Task SendMessageAsync(ThirdPartyIntegration message);
    }
}
