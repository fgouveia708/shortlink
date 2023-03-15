using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IBaseQueue<T> where T : class
    {
        Task SendMessageAsync(T message, string queueUrl);
    }
}
