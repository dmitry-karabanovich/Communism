using System;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Data.EntityFramework.Repositories;
using Moq;
using Xunit;

namespace Communism.Data.Test
{
    public class UserRepositoryTest : CommunismDataTestBase
    {
        [Fact]
        public void GetUserByUserName_UserName_ReceiveAppropriateUser()
        {
            //Arrange
            var dbContext = new Mock<CommunismContext>();
            var users = new[]
            {
                new User
                {
                    Uid = new Guid("a71c3f4f-f216-46bd-ac49-e2830fadfb2a"),
                    UserName = "dkarabanovich",
                    FirstName = "Dzmitry",
                    LastName = "Karabanovich"
                },
                new User
                {
                    Uid = new Guid("851840ce-6b70-4f99-b3a5-6d9733b3faad"),
                    UserName = "duser",
                    FirstName = "User",
                    LastName = "User"
                },
            };
            var dbSet = MockDbSet(users);
            dbContext.Setup(x => x.Users).Returns(dbSet.Object);
            var userRepository = new UserRepository(dbContext.Object);

            //Act
            var user = userRepository.GetUserByUserName("dkarabanovich");

            //Assert
            Assert.Equal("dkarabanovich", user.UserName);
            Assert.Equal(new Guid("a71c3f4f-f216-46bd-ac49-e2830fadfb2a"), user.Uid);
            //Check full object
        }
    }
}
