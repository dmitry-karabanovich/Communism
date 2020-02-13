using System;

namespace Communism.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
