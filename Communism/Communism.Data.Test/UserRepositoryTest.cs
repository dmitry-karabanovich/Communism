using System;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Data.EntityFramework.Repositories;
using Communism.Domain.Contracts.Dtos;
using Moq;
using Xunit;

namespace Communism.Data.Test
{
    public class UserRepositoryTest : CommunismDataTestBase
    {
        [Fact]
        public void GetUserByUid_UserUid_UserDto()
        {
            //Arrange
            var testUserDto = new UserDto();
            var dbContext = new Mock<CommunismContext>();
            var users = new[]
            {
                new User
                {
                    Uid = new Guid(),
                    UserName = "dkarabanovich",
                    FirstName = "Dzmitry",
                    LastName = "Karabanovich"
                }, 
            };
            var dbSet = MockDbSet<User>(users);
            dbContext.Setup(x => x.Users).Returns(dbSet.Object);
            var userRepository = new UserRepository(dbContext.Object);

           

            var user = userRepository.GetUserByUserName("dkarabanovich");

            Assert.Equal("Dzmity", user.UserName);
        }
    }
}
