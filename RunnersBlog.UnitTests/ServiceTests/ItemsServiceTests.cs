﻿using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services.ItemsServices;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class ItemsServiceTests
    {
        private readonly Mock<IItemsRepository> mockItemsRepository;
        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        public CancellationToken cancellationToken;
        public ItemsServiceTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            cancellationToken = new CancellationToken();
            mockItemsRepository = new Mock<IItemsRepository>();
        }
        [Fact]
        public void CreateAsync()
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
            .Returns(Task.FromResult(new ApplicationUser()));

            var sut = GetSut();

            //Act
            var result = sut.CreateAsync(email, itemDto, cancellationToken);

            //Assert
            result.Should().NotBeNull();
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

            mockItemsRepository.Setup(x => x.GetItemAsync(
                mockItemId,
                CancellationToken.None
                )).ReturnsAsync(new Item());

            //Act

            var result = sut.DeleteByIdAsync(mockItemId, cancellationToken);
            //Assert

            result.Should().NotBeNull();
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

            mockItemsRepository.Setup(x => x
            .GetItemAsync(
                mockItemId,
                cancellationToken))
            .Returns(Task.FromResult(new Item()));

            var sut = GetSut();

            //Act
            var result = sut.GetByIdAsync(mockItemId, cancellationToken);

            //Assert
            result.Should().NotBeNull();
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

            mockItemsRepository.Setup(x => x.GetItemAsync(
                mockItemId,
                CancellationToken.None)).ReturnsAsync(new Item());

            var sut = GetSut();

            //Act
            var result = sut.UpdateByIdAsync(mockItemId, itemDto, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void MiddlePage()
        {
            //Arrange
            var mockId = Guid.NewGuid();

            var sut = GetSut();

            //Act
            var result = sut.MiddlePage(mockId, CancellationToken.None);

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
            .Returns(Task.FromResult(new ApplicationUser()));

            var sut = GetSut();

            //Act
            var result = sut.ReserveItemAsync(email, mockGuid, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void ReservedItemsList()
        {
            //Arrange
            var email = "test@test.com";

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(new ApplicationUser()));

            var sut = GetSut();

            //Act
            var result = sut.ReservedItemsListAsync(email, cancellationToken);

            //Assert
            result.Should().NotBeNull();
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
            .Returns(Task.FromResult(new ApplicationUser()));

            var sut = GetSut();

            //Act
            var result = sut.CancelReservedItem(email, mockGuid, cancellationToken);

            //Assert
            result.Should().NotBeNull();
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
            .Returns(Task.FromResult(new ApplicationUser()));

            var sut = GetSut();

            //Act
            var result = sut.BuyReservedItem(email, mockGuid, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        public ItemsService GetSut()
             => new(mockItemsRepository.Object,
                    mockUserManager.Object);
    }
}
