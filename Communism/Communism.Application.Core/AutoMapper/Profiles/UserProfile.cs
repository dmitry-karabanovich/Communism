using AutoMapper;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Application.Core.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(nameof(UserDto.Uid), x => x.MapFrom(y => y.Uid))
                .ForMember(nameof(UserDto.UserName), x => x.MapFrom(y => y.UserName))
                .ForMember(nameof(UserDto.FirstName), x => x.MapFrom(y => y.FirstName))
                .ForMember(nameof(UserDto.LastName), x => x.MapFrom(y => y.LastName))
                .ForMember(nameof(UserDto.UserRole), x => x.MapFrom(y => y.Role.Name));
        }
    }
}