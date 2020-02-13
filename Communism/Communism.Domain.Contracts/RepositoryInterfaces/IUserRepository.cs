using Communism.Domain.Contracts.Dtos;

namespace Communism.Domain.Contracts.RepositoryInterfaces
{
    public interface IUserRepository
    {
        UserDto GetUserByUserName(string userName);
    }
}
