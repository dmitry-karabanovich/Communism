using System.Collections.Generic;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Domain.Contracts.ServiceInterfaces
{
    public interface IUserQueryService
    {
        TDto GetUserByUserName<TDto>(string userName) where TDto : class;
        IEnumerable<TDto> GetAllUsers<TDto>() where TDto : class;

    }
}
