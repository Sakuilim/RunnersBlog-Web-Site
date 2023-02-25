using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DataAccessLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using DataAccessLayer.Models.Items;
using RunnersBlogMVC.Services.ItemsServices;
using DataAccessLayer.Data;
using System.Collections.Generic;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class ItemsServiceTests
    {
        private readonly Mock<IItemsData> mockItemsRepository;
        private readonly Mock<UserManager<User>> mockUserManager;
        public CancellationToken cancellationToken;
        public ItemsServiceTests()
        {
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            cancellationToken = new CancellationToken();
            mockItemsRepository = new Mock<IItemsData>();
        }
        [Fact]
        public void WhenItemIsCorrect_CreateAsync_ShouldReturnSuccess()
        {
            //Arrange
            var email = "test@test.com";

            var itemDto = new ItemDto()
            {
                Name = "Test",
                Price = 1.00M
            };

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            var sut = GetSut();

            //Act
            var result = sut.CreateAsync(email, itemDto, cancellationToken);

            //Assert
            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void DeleteByIdAsync()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();

            var sut = GetSut();

            //Act
            var result = sut.DeleteByIdAsync(mockItemId, cancellationToken);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void DeleteByIdAsync_Exists()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();

            var sut = GetSut();

            mockItemsRepository.Setup(x => x.GetItem(
                mockItemId
                )).ReturnsAsync(new Item());

            //Act

            var result = sut.DeleteByIdAsync(mockItemId, cancellationToken);
            //Assert
            mockItemsRepository.Verify(x => x.GetItem(mockItemId
                ), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<Item>>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void GetAllAsync()
        {
            //Arrange

            var sut = GetSut();

            //Act
            var result = sut.GetAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void GetByIdAsync()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();
            var sut = GetSut();

            //Act
            var result = sut.GetByIdAsync(mockItemId, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void GetByIdAsync_ItemNotNull()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();

            mockItemsRepository.Setup(x => x.GetItem(
                mockItemId))
            .ReturnsAsync(new Item());

            var sut = GetSut();

            //Act
            var result = sut.GetByIdAsync(mockItemId, cancellationToken);

            //Assert
            mockItemsRepository.Verify(x => x.GetItem(mockItemId), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult<Item>>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void UpdateByIdAsync()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();
            var itemDto = new ItemDto()
            {
                Name = "Test",
                Price = 1.00M
            };

            var sut = GetSut();

            //Act
            var result = sut.UpdateByIdAsync(mockItemId, itemDto, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void UpdateByIdAsync_Exists()
        {
            //Arrange
            var mockItemId = Guid.NewGuid();
            var itemDto = new ItemDto()
            {
                Name = "Test",
                Price = 1.00M
            };

            mockItemsRepository.Setup(x => x.GetItem(
                mockItemId))
            .ReturnsAsync(new Item());

            var sut = GetSut();

            //Act
            var result = sut.UpdateByIdAsync(mockItemId, itemDto, cancellationToken);

            //Assert
            mockItemsRepository.Verify(x => x.GetItem(mockItemId), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void MiddlePage()
        {
            //Arrange
            var mockId = Guid.NewGuid();

            var sut = GetSut();

            //Act
            var result = sut.MiddlePageAsync(mockId, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();

        }
        [Fact]
        public void GetOrderedItems()
        {
            //Arrange
            var sut = GetSut();

            //Act
            var result = sut.GetOrderedItemsAsync("Price", cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void ReserveItem()
        {
            //Arrange
            var email = "test@test.com";

            var mockGuid = Guid.NewGuid();

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            mockItemsRepository.Setup(x => x
                .GetItems())
            .ReturnsAsync(new List<Item>());

            mockItemsRepository.Setup(x => x
                .GetItem(mockGuid))
            .ReturnsAsync(new Item());

            var sut = GetSut();

            //Act
            var result = sut.ReserveItemAsync(email, mockGuid, cancellationToken);

            //Assert
            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void ReservedItemsList_Should_ReturnReservedItemsList()
        {
            //Arrange
            var email = "test@test.com";

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            var sut = GetSut();

            //Act
            var result = sut.ReservedItemsListAsync(email, cancellationToken);

            //Assert
            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void CancelReservedItem()
        {
            //Arrange
            var email = "test@test.com";

            var mockGuid = Guid.NewGuid();

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            var sut = GetSut();

            //Act
            var result = sut.CancelReservedItemAsync(email, mockGuid, cancellationToken);

            //Assert
            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        [Fact]
        public void BuyReservedItem()
        {
            //Arrange
            var email = "test@test.com";

            var mockGuid = Guid.NewGuid();

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            var sut = GetSut();

            //Act
            var result = sut.BuyReservedItemAsync(email, mockGuid, cancellationToken);

            //Assert
            mockUserManager.Verify(x => x.FindByEmailAsync(It.IsAny<string>()), Times.Once);
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
            result.Should().BeAssignableTo<Task>();
        }
        public ItemsService GetSut()
             => new(mockItemsRepository.Object,
                    mockUserManager.Object);
    }
}
