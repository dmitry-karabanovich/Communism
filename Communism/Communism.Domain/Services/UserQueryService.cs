using Communism.Domain.Contracts;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.RepositoryInterfaces;
using Communism.Domain.Contracts.ServiceInterfaces;

namespace Communism.Domain.Services
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserQueryService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public UserDto GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }
    }
}
