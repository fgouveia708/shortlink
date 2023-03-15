using Domain.Entities;
using System;

namespace Domain.Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(Guid id);
    }
}
