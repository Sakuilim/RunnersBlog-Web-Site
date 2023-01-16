using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.DataAccess;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataAccessLayer.UnitTests.UserDataTests
{
    public class UserDataAccessTests
    {
        private readonly Mock<ISqlDataAccess> mockSqlDataAccess;
        public UserDataAccessTests()
        {
            mockSqlDataAccess = new Mock<ISqlDataAccess>();
        }
        [Fact]
        public async Task When_GetUsersQueryIsCorrectLoadData_ShouldLoadUsers()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User
            {
                UserId = 123,
                Email = "email@email.com",
                Name = "test2"
            };
            var fakeEnumerable = new List<User>
            {
                fakeUser
            };

            mockSqlDataAccess.Setup(x => x
            .LoadData<User, dynamic>(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()))
            .ReturnsAsync(fakeEnumerable);

            //Act
            var result = await sut.GetUsers();
            //Assert
            result.Should().NotBeNull();
            result.First().Should().Be(fakeUser);

        }
        [Fact]
        public async Task When_GetUsersQueryIsWrongLoadData_ShouldLoadNull()
        {
            //Arrange
            var sut = GetSut();

            //Act
            var result = await sut.GetUsers();

            //Assert
            result.Should().BeEmpty();

        }
        [Fact]
        public async Task When_GetUserQueryIsCorrectLoadData_ShouldLoadUser()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User
            {
                UserId = 123,
                Email = "email@email.com",
                Name = "test2"
            };
            var fakeEnumerable = new List<User>
            {
                fakeUser
            };

            mockSqlDataAccess.Setup(x => x
            .LoadData<User, dynamic>(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()))
            .ReturnsAsync(fakeEnumerable);

            //Act
            var result = await sut.GetUser(fakeUser.UserId);
            //Assert
            result.Should().NotBeNull();
            result.Should().Be(fakeUser);

        }
        [Fact]
        public async Task When_GetUserQueryIsWrongLoadData_ShouldLoadNull()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User();

            //Act
            var result = await sut.GetUser(fakeUser.UserId);

            //Assert
            result.Should().BeNull();

        }
        [Fact]
        public async Task When_SaveUserQueryIsCorrectLoadData_ShouldSaveUser()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User
            {
                UserId = 123,
                Email = "email@email.com",
                Name = "test2"
            };

            //Act
            await sut.InsertUser(fakeUser);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()),
                Times.Once);

        }
        [Fact]
        public async Task When_SaveUserQueryIsWrongLoadData_ShouldSaveNull()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User();

            //Act
            await sut.InsertUser(fakeUser);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()),
                Times.Once);

        }
        [Fact]
        public async Task When_UpdateUserQueryIsCorrectLoadData_ShouldUpdateUser()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User
            {
                UserId = 123,
                Email = "email@email.com",
                Name = "test2"
            };

            //Act
            await sut.UpdateUser(fakeUser);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                fakeUser,
                It.IsAny<string>()),
                Times.Once);

        }
        [Fact]
        public async Task When_DeleteUserQueryIsCorrectSaveData_ShouldDelete()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User
            {
                UserId = 123,
                Email = "email@email.com",
                Name = "test2"
            };

            //Act
            await sut.DeleteUser(fakeUser.UserId);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()),
                Times.Once);

        }
        [Fact]
        public async Task When_DeleteUserQueryIsWrongLoadData_ShouldNotDelete()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new User();

            //Act
            await sut.DeleteUser(fakeUser.UserId);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()),
                Times.Once);

        }

        public UserData GetSut()
            => new(mockSqlDataAccess.Object);
    }
}