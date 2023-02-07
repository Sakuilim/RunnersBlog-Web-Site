using FluentAssertions;
using Xunit;
using RunnersBlogMVC.Controllers;

namespace RunnersBlogMVC.UnitTests.ControllerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index()
        {
            //Arrange
            var sut = GetSut();
            //Act
            var result = sut.Index();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Privacy()
        {
            //Arrange
            var sut = GetSut();
            //Act
            var result = sut.Privacy();
            //Assert
            result.Should().NotBeNull();
        }

        public static HomeController GetSut()
            => new();
    }
}
