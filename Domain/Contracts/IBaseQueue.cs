namespace Domain.Contracts
{
    public interface IBaseQueue<T> where T : class
    {
        void SendMessage(T message, string queueName);
    }
}
