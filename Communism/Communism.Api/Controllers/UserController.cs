using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Communism.Api.Models;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.ServiceInterfaces;

namespace Communism.Api.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserQueryService _userQueryService;
        private readonly IMapper _mapper;

        public UserController(IUserQueryService userQueryService, IMapper mapper)
        {
            _userQueryService = userQueryService;
            _mapper = mapper;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _mapper.Map<IEnumerable<UserDto>, IEnumerable<UserModel>>(_userQueryService.GetAllUsers<UserDto>());
        }
    }
}
