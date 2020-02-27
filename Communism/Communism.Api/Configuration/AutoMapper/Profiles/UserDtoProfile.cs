using AutoMapper;
using Communism.Api.Models;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Api.Configuration.AutoMapper.Profiles
{
    public class UserDtoProfile : Profile
    {
        public UserDtoProfile()
        {
            CreateMap<UserInfoDto, UserModel>()
                .ForMember(nameof(UserModel.Uid), x => x.MapFrom(y => y.Uid))
                .ForMember(nameof(UserModel.UserName), x => x.MapFrom(y => y.UserName))
                .ForMember(nameof(UserModel.FirstName), x => x.MapFrom(y => y.FirstName))
                .ForMember(nameof(UserModel.LastName), x => x.MapFrom(y => y.LastName))
                .ForMember(nameof(UserModel.UserRole), x => x.MapFrom(y => y.UserRole));
        }
    }
}