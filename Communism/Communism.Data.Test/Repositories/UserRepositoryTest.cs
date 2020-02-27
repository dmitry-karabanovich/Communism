using System;
using System.Collections.Generic;
using System.Data.Entity;
using AutoMapper;
using FluentAssertions;
using Moq;
using Xunit;
using Communism.Application.Core.AutoMapper.Profiles;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.DataBase.Entities;
using Communism.Data.EntityFramework.Repositories;
using Communism.Domain.Contracts.Dtos;

namespace Communism.Data.Test.Repositories
{
    public class UserRepositoryTest : CommunismDataTestBase
    {
        private readonly Mock<DbSet<User>> _dbSet;
        private readonly List<User> _entityTestList;

        public UserRepositoryTest()
        {
            _entityTestList = GenerateUserEntityList();
            _dbSet = MockDbSet(_entityTestList);
        }

        [Fact]
        public void GetUserByUserName_UserName_ReceiveAppropriateUser()
        {
            //Arrange
            var context = new Mock<CommunismContext>();
            context.Setup(x => x.Users).Returns(_dbSet.Object);
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            var userRepository = new UserRepository(context.Object, mapper);

            //Act
            var user = userRepository.GetUserByUserName<UserDto>("duser2");

            //Assert
            mapper.Map<User, UserDto>(_entityTestList[2]).Should().BeEquivalentTo(user);
        }
        
        [Fact]
        public void GetAllUser_ReceiveAppropriateUsers()
        {
            //Arrange
            var context = new Mock<CommunismContext>();
            context.Setup(x => x.Users).Returns(_dbSet.Object);
            context.Setup(x => x.Set<User>()).Returns(_dbSet.Object);
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            var userRepository = new UserRepository(context.Object, mapper);

            //Act
            var users = userRepository.GetAll<UserDto>();

            //Assert
            mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(_entityTestList).Should().BeEquivalentTo(users);
        }

        [Fact]
        public void GetByUid_UserUid_ReceiveAppropriateUserInfo()
        {
            //Arrange
            var context = new Mock<CommunismContext>();
            context.Setup(x => x.Users).Returns(_dbSet.Object);
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            context.Setup(x => x.Set<User>()).Returns(_dbSet.Object);
            var userRepository = new UserRepository(context.Object, mapper);

            //Act
            var user = userRepository.GetByUid<UserInfoDto>(_entityTestList[0].Uid);

            //Assert
            mapper.Map<User, UserInfoDto>(_entityTestList[0]).Should().BeEquivalentTo(user);
        }

        [Fact]
        public void AddUser_UserDto_AddAppropriateUser()
        {
            //Arrange
            var userThatWasCreated = new User();
            var context = new Mock<CommunismContext>();
            context.Setup(x => x.Users).Returns(_dbSet.Object);
            context.Setup(x => x.Set<User>()).Returns(_dbSet.Object);
            context.Setup(x => x.Set<User>().Add(It.IsAny<User>())).Callback((User u) => userThatWasCreated = u);
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            var userRepository = new UserRepository(context.Object, mapper);
            var userDto = new UserDto
            {
                UserName = "duser4",
                FirstName = "User4",
                LastName = "User4",
                UserRoleUid = Guid.NewGuid()
            };
           
            //Act
            userRepository.Add(userDto);

            //Assert
            context.Verify(x => x.Set<User>().Add(It.IsAny<User>()), Times.Once);
            mapper.Map<User, UserDto>(userThatWasCreated).Should().BeEquivalentTo(userDto);
        }

        [Fact]
        public void UpdateUser_UserDto_AppropriateUserUpdate()
        {
            //Arrange
            var updatedUser = new User();
            var context = new Mock<CommunismContext>();
            context.Setup(x => x.Users).Returns(_dbSet.Object);
            context.Setup(x => x.Set<User>()).Returns(_dbSet.Object);
            context.Setup(x => x.Set<User>().Attach(It.IsAny<User>())).Callback((User u) => updatedUser = u);
            var mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile(new UserProfile());
            });
            var mapper = mapperConfiguration.CreateMapper();
            var userRepository = new UserRepository(context.Object, mapper);
            var userDto = new UserDto
            {
                Uid = _entityTestList[3].Uid,
                UserName = "duser33",
                FirstName = "User33",
                LastName = "User33",
                UserRoleUid = _entityTestList[3].RoleUid,
            };

            //Act
            userRepository.Update(userDto);

            //Assert
            context.Verify(x => x.Set<User>().Attach(It.IsAny<User>()), Times.Once);
            context.Verify(x => x.Entry(It.IsAny<User>()), Times.Once);
            mapper.Map<User, UserDto>(updatedUser).Should().BeEquivalentTo(userDto);
        }

        private List<User> GenerateUserEntityList()
        {
            return new List<User>
            {
                new User
                {
                    Uid = Guid.NewGuid(),
                    UserName = "dkarabanovich",
                    FirstName = "Dzmitry",
                    LastName = "Karabanovich",
                    RoleUid = Guid.NewGuid()
                },
                new User
                {
                    Uid = Guid.NewGuid(),
                    UserName = "duser1",
                    FirstName = "User1",
                    LastName = "User1",
                    RoleUid = Guid.NewGuid()
                },
                new User
                {
                    Uid = Guid.NewGuid(),
                    UserName = "duser2",
                    FirstName = "User2",
                    LastName = "User2",
                    RoleUid = Guid.NewGuid()
                },
                new User
                {
                    Uid = Guid.NewGuid(),
                    UserName = "duser3",
                    FirstName = "User3",
                    LastName = "User3",
                    RoleUid = Guid.NewGuid()
                }
            };
        }
    }
}
