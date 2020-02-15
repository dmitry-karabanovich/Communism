using AutoMapper;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Application.Core.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}