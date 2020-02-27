using AutoMapper;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Application.Core.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserInfoDto>()
                .ForMember(nameof(UserInfoDto.Uid), x => x.MapFrom(y => y.Uid))
                .ForMember(nameof(UserInfoDto.UserName), x => x.MapFrom(y => y.UserName))
                .ForMember(nameof(UserInfoDto.FirstName), x => x.MapFrom(y => y.FirstName))
                .ForMember(nameof(UserInfoDto.LastName), x => x.MapFrom(y => y.LastName))
                .ForMember(nameof(UserInfoDto.UserRole), x => x.MapFrom(y => y.Role.Name));

            CreateMap<UserDto, User>()
                .ForMember(nameof(User.UserName), x => x.MapFrom(y => y.UserName))
                .ForMember(nameof(User.FirstName), x => x.MapFrom(y => y.FirstName))
                .ForMember(nameof(User.LastName), x => x.MapFrom(y => y.LastName))
                .ForMember(nameof(User.RoleUid), x => x.MapFrom(y => y.UserRoleUid))
                .ForMember(nameof(User.DenunciationsToThisUser), x => x.Ignore())
                .ForMember(nameof(User.OwnDenunciations), x => x.Ignore())
                .ForMember(nameof(User.Role), x => x.Ignore());

            CreateMap<User, UserDto>()
                .ForMember(nameof(UserDto.Uid), x => x.MapFrom(y => y.Uid))
                .ForMember(nameof(UserDto.UserName), x => x.MapFrom(y => y.UserName))
                .ForMember(nameof(UserDto.FirstName), x => x.MapFrom(y => y.FirstName))
                .ForMember(nameof(UserDto.LastName), x => x.MapFrom(y => y.LastName))
                .ForMember(nameof(UserDto.UserRoleUid), x => x.MapFrom(y => y.RoleUid));

        }
    }
}