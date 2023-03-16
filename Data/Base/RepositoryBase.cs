using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public virtual T Create(T entity)
        {
            var now = DateTime.Now;

            entity.Id = Guid.NewGuid();
            entity.CreatedAt = now;
            entity.UpdatedAt = now;

            Set.Add(entity);

            this.Commit();

            return entity;
        }

        public virtual void Delete(Guid id)
        {
            T entity = Set.FirstOrDefault(s => s.Id == id);
            entity.Deleted = true;

            this.Update(entity);
        }

        public virtual void Update(T entity)
        {
            entity.UpdatedAt = DateTime.Now;
            _context.Entry(entity).State = EntityState.Modified;
            this.Commit();
        }

        public IQueryable<T> FindAll()
        {
            return Set.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            var query = Set.Where(expression);
            query = query.Where(w => !w.Deleted);

            return query.AsNoTracking();
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
