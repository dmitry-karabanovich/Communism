using Communism.Domain.Contracts.Dtos;

namespace Communism.Domain.Contracts.ServiceInterfaces
{
    public interface IUserQueryService
    {
        UserDto GetUserByUserName(string userName);
    }
}
