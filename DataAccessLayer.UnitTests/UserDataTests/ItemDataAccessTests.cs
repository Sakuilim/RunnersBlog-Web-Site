using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Models.Items;
using DataAccessLayer.Repositories.DataAccess;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataAccessLayer.UnitTests.UserDataTests
{
    public class ItemDataAccessTests
    {
        private readonly Mock<ISqlDataAccess> mockSqlDataAccess;
        public ItemDataAccessTests()
        {
            mockSqlDataAccess = new Mock<ISqlDataAccess>();
        }
        [Fact]
        public async Task When_GetUsersQueryIsCorrectLoadData_ShouldLoadUsers()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new Item
            {
                Id = Guid.NewGuid()
            };
            var fakeEnumerable = new List<Item>
            {
                fakeUser
            };

            mockSqlDataAccess.Setup(x => x
            .LoadData<Item, dynamic>(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()))
            .ReturnsAsync(fakeEnumerable);

            //Act
            var result = await sut.GetItems();
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
            var result = await sut.GetItems();

            //Assert
            result.Should().BeEmpty();

        }
        [Fact]
        public async Task When_GetUserQueryIsCorrectLoadData_ShouldLoadUser()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new Item
            {
                Id = Guid.NewGuid(),
            };
            var fakeEnumerable = new List<Item>
            {
                fakeUser
            };

            mockSqlDataAccess.Setup(x => x
            .LoadData<Item, dynamic>(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()))
            .ReturnsAsync(fakeEnumerable);

            //Act
            var result = await sut.GetItem(fakeUser.Id);
            //Assert
            result.Should().NotBeNull();
            result.Should().Be(fakeUser);

        }
        [Fact]
        public async Task When_GetUserQueryIsWrongLoadData_ShouldLoadNull()
        {
            //Arrange
            var sut = GetSut();
            var fakeItem = new Item();

            //Act
            var result = await sut.GetItem(fakeItem.Id);

            //Assert
            result.Should().BeNull();

        }
        [Fact]
        public async Task When_SaveUserQueryIsCorrectLoadData_ShouldSaveUser()
        {
            //Arrange
            var sut = GetSut();
            var fakeUser = new Item
            {
                Id = Guid.NewGuid()
            };

            //Act
            await sut.InsertItem(fakeUser);

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
            var fakeItem = new Item();

            //Act
            await sut.InsertItem(fakeItem);

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
            var fakeItem = new Item
            {
                Id = Guid.NewGuid()
            };

            //Act
            await sut.UpdateItem(fakeItem);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                fakeItem,
                It.IsAny<string>()),
                Times.Once);

        }
        [Fact]
        public async Task When_DeleteUserQueryIsCorrectSaveData_ShouldDelete()
        {
            //Arrange
            var sut = GetSut();
            var fakeItem = new Item
            {
                Id = Guid.NewGuid()
            };

            //Act
            await sut.DeleteItem(fakeItem.Id);

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
            var fakeItem = new Item();

            //Act
            await sut.DeleteItem(fakeItem.Id);

            //Assert
            mockSqlDataAccess.Verify(x => x.SaveData(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<string>()),
                Times.Once);

        }

        public ItemsData GetSut()
            => new(mockSqlDataAccess.Object);
    }
}