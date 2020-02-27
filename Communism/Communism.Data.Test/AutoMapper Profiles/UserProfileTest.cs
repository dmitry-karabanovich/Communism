using AutoMapper;
using Communism.Application.Core.AutoMapper.Profiles;
using Xunit;

namespace Communism.Data.Test.AutoMapper_Profiles
{
    public class UserProfileTest
    {
        [Fact]
        public void User_UserDto_Profile()
        {
            var configuration = new MapperConfiguration(x => x.AddProfile(new UserProfile()));
            configuration.AssertConfigurationIsValid();
        }
    }
}
