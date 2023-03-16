using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;

namespace Data
{
    public class ShortlinkContext : DbContext
    {
        public ShortlinkContext(DbContextOptions<ShortlinkContext> options)
        : base(options)
        { }

        public DbSet<Shortlink> Shortlink { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shortlink>().HasData(SeedData().AsEnumerable());
        }

        public List<Shortlink> SeedData()
        {
            var shortlinks = new List<Shortlink>();
            using (StreamReader r = new StreamReader("initial-data.json"))
            {
                string json = r.ReadToEnd();
                var data = JsonConvert.DeserializeObject<List<ShortlinkSeedData>>(json);
                var now = DateTime.Now;
                shortlinks.AddRange(data.Take(5).Select(c => new Shortlink()
                {
                    ShortUrl = c.ShortUrl,
                    Hint = c.Hit,
                    Url = c.Url,
                    Id = Guid.NewGuid(),
                    CreatedAt = now,
                    UpdatedAt = now,
                    Deleted = false
                }));
            }
            return shortlinks;
        }
    }
}
