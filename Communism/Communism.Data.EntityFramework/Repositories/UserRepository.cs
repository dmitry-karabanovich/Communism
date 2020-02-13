using System.Linq;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.RepositoryInterfaces;

namespace Communism.Data.EntityFramework.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(CommunismContext context) : base(context)
        {
        }

        public UserDto GetUserByUserName(string userName)
        {
            return Context.Users.Where(x => x.UserName == userName).Select(x => new UserDto
            {
                Uid = x.Uid,
                UserName = x.UserName,
                FirstName = x.FirstName
            }).Single();
        }
    }
}
