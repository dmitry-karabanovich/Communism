using System;
using Communism.Data.EntityFramework.DataBase;
using Communism.Domain.Contracts;

namespace Communism.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CommunismContext _dbContext;
        public UnitOfWork(CommunismContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
