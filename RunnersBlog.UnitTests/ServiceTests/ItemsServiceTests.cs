using FluentAssertions;
using Moq;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class ItemsServiceTests
    {
        private readonly Mock<IItemsRepository> mockItemsRepository;
        public CancellationToken cancellationToken;
        public ItemsServiceTests()
        {
            cancellationToken = new CancellationToken();
            mockItemsRepository = new Mock<IItemsRepository>();
        }
        [Fact]
        public void CreateAsync()
        {
            //Arrange
            var itemDto = new ItemDto()
            {
                Name = "Test",
                Price = 1.00M
            };

            var sut = GetSut();

            //Act
            var result = sut.CreateAsync(itemDto, cancellationToken);

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
        public ItemsService GetSut()
             => new(mockItemsRepository.Object);
    }
}
