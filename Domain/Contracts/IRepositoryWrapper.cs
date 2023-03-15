namespace Domain.Contracts
{
    public interface IRepositoryWrapper
    {
        IShortlinkRepository Shortlink { get; }
        void Save();
    }
}
