using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(Guid id);
        void Update(T entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
