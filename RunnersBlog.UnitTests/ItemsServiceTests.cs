using FluentAssertions;
using Moq;
using RunnersBlogMVC.DTO;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests
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
        public void Test1()
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
        public void Test2()
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
        public void Test3()
        {
            //Arrange

            var sut = GetSut();

            //Act
            var result = sut.GetAllAsync(cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Test4()
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
        public void Test5()
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

        public ItemsService GetSut()
             => new(mockItemsRepository.Object);
    }
}
