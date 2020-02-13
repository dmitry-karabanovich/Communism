using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Communism.Data.EntityFramework.DataBase;

namespace Communism.Data.EntityFramework
{
    public abstract class GenericRepository<T> where T : class
    {
        internal CommunismContext Context;
        internal DbSet<T> DbSet;

        protected GenericRepository(CommunismContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var entitiesToRemove = DbSet.Where(where);
            DbSet.RemoveRange(entitiesToRemove);
        }

        public virtual T GetByUid(Guid uid)
        {
            return DbSet.Find(uid);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> where)
        {
            return DbSet.Where(where).ToArray();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToArray();
        }
    }
}
