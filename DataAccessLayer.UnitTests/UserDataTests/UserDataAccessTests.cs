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

        public UserData GetSut()
            => new(mockSqlDataAccess.Object);
    }
}