using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Data.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Identifier
    {
        private ShortlinkContext _context;

        public RepositoryBase(ShortlinkContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Create(T entity)
        {
            Set.Add(entity);

            this.Commit();
        }

        public virtual void Delete(Guid id)
        {
            T entity = Set.FirstOrDefault(s => s.Id == id);

            Set.Remove(entity);

            this.Commit();
        }

        protected DbSet<T> Set
        {
            get
            {
                return _context.Set<T>();
            }
        }
    }
}
