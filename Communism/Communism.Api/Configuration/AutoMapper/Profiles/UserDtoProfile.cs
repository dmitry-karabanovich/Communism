using AutoMapper;
using Communism.Api.Models;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Api.Configuration.AutoMapper.Profiles
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserDto, UserModel>();
        }
    }
}