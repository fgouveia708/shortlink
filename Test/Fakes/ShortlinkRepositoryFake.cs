using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Fakes
{
    public class ShortlinkRepositoryFake
    {
        public static Shortlink Shortlink =>
          new Shortlink()
          {
              Id = Guid.NewGuid(),
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              Hint = 0,
              Deleted = false,
              ShortUrl = "http://chr.dc/9op3",
              Url = "http://www.google.com"
          };

        public static IQueryable<Shortlink> Shortlinks =>
          new List<Shortlink>() {
          new Shortlink()
          {
              Id = Guid.NewGuid(),
              CreatedAt = DateTime.Now,
              UpdatedAt = DateTime.Now,
              Hint = 0,
              Deleted = false,
              ShortUrl = "http://chr.dc/9op3",
              Url = "http://www.google.com"
          }}.AsQueryable();
    }
}
