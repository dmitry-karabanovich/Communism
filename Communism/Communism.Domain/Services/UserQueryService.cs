using System.Collections.Generic;
using Communism.Domain.Contracts;
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

        public TDto GetUserByUserName<TDto>(string userName) where TDto : class
        {
            return _userRepository.GetUserByUserName<TDto>(userName);
        }

        public IEnumerable<TDto> GetAllUsers<TDto>() where TDto : class
        {
            return _userRepository.GetAll<TDto>();
        }
    }
}
