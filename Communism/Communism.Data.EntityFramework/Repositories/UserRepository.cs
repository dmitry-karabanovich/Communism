using System.Linq;
using AutoMapper;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.RepositoryInterfaces;

namespace Communism.Data.EntityFramework.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CommunismContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public UserDto GetUserByUserName(string userName)
        {
            return Mapper.Map<User, UserDto>(Context.Users.Single(x => x.UserName == userName));
        }
    }
}
