using System.Linq;
using AutoMapper;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.RepositoryInterfaces;

namespace Communism.Data.EntityFramework.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CommunismContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public TDto GetUserByUserName<TDto>(string userName) where TDto : class
        {
            return Mapper.Map<User, TDto>(Context.Users.Single(x => x.UserName == userName));
        }
    }
}
