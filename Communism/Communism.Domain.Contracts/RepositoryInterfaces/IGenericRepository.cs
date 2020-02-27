using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Communism.Domain.Contracts.RepositoryInterfaces
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
//        void Delete<T>(Expression<Func<T, bool>> where) where T : class;
        T GetByUid<T>(Guid uid) where T : class;
//        IEnumerable<T> Get<T>(Expression<Func<T, bool>> where) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
    }
}
