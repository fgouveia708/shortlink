using Data.Base;
using Domain.Contracts;
using Domain.Entities;

namespace Data
{
    public class ShortlinkRepository : RepositoryBase<Shortlink>, IShortlinkRepository
    {
        public ShortlinkRepository(ShortlinkContext context) : base(context)
        {
        }
    }
}
