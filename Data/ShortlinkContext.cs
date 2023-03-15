using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ShortlinkContext : DbContext
    {


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //   => optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Pooling=true;Database=postgres;User Id=admin;Password=numsey*Password!");
        public ShortlinkContext(DbContextOptions<ShortlinkContext> options)
        : base(options)
        { }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Shortlink>().HasKey(t => t.Id);
        //}
        public  DbSet<Shortlink> Shortlink { get; set; }

    }
}
