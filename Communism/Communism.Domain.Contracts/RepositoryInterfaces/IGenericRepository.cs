using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Communism.Domain.Contracts.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetByUid(Guid uid);
        IEnumerable<T> Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
    }
}
