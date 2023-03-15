using Domain.Contracts;

namespace Data.Base
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ShortlinkContext _context;
        private IShortlinkRepository _shortlink;
        public IShortlinkRepository Shortlink
        {
            get
            {
                if (_shortlink == null)
                {
                    _shortlink = new ShortlinkRepository(_context);
                }
                return _shortlink;
            }
        }
        public RepositoryWrapper(ShortlinkContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}