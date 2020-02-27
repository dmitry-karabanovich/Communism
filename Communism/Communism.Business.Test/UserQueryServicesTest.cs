using System;
using Communism.Domain.Contracts;
using Communism.Domain.Contracts.Dtos;
using Communism.Domain.Contracts.RepositoryInterfaces;
using Communism.Domain.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace Communism.Business.Test
{
    public class UserQueryServicesTest
    {
        [Fact]
        public void GetUserByUserName_UserName_ReceiveAppropriateUser()
        {
            //Arrange
            var userDto = new UserDto
            {
                Uid = Guid.NewGuid(),
                UserName = "dkarabanovich",
                FirstName = "Dzmitry",
                LastName = "Karabanovich",
                UserRoleUid = Guid.NewGuid()
            };
            var unitOfWork = new Mock<IUnitOfWork>();
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetUserByUserName<UserDto>(It.IsNotNull<string>())).Returns(userDto);
            var userQueryService = new UserQueryService(unitOfWork.Object, userRepository.Object);
            
            //Act
            var user = userQueryService.GetUserByUserName<UserDto>("dkarabanovich");

            //Assert
            userRepository.Verify(x => x.GetUserByUserName<UserDto>(It.IsAny<string>()), Times.Once);
            userDto.Should().BeEquivalentTo(user);
        }
    }
}
