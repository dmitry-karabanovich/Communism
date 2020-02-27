using Communism.Domain.Contracts.Dtos;

namespace Communism.Domain.Contracts.RepositoryInterfaces
{
    public interface IUserRepository : IGenericRepository
    {
        TDto GetUserByUserName<TDto>(string userName) where TDto : class;
    }
}
