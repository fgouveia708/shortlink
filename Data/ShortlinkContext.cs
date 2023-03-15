using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ShortlinkContext : DbContext
    {
        public ShortlinkContext(DbContextOptions<ShortlinkContext> options)
        : base(options)
        { }

        public DbSet<Shortlink> Shortlink { get; set; }

    }
}
