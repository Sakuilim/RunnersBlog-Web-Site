using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class UserServiceTests
    {
        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        private readonly Mock<RoleManager<ApplicationRole>> mockRoleManager;

        public UserServiceTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            mockRoleManager = new Mock<RoleManager<ApplicationRole>>(Mock.Of<IRoleStore<ApplicationRole>>(), null, null, null, null);
        }

        [Fact]
        public void UserPage_Should_ReturnDefaultView()
        {
            //Arrange
            var sut = GetSut();

            //Act
            var result = sut.CreateAsync(null, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<ActionResult>>();
        }

        [Fact]
        public async Task UserPage_Should_ReturnSomething()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2"
            };

            mockUserManager.Setup(x => x
            .CreateAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
            .Returns(Task.FromResult(IdentityResult.Success));

            var sut = GetSut();

            //Act
            var result = await sut.CreateAsync(user, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task UserPage_Should_FailReturnSomething()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2",
                Password= "password"
            };

            mockUserManager.Setup(x => x
            .CreateAsync(
                It.IsAny<ApplicationUser>(),
                user.Password))
            .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError
            { 
                Code = "errorCode",
                Description = "errorDesc"
            })));

            var sut = GetSut();

            //Act
            var result = await sut.CreateAsync(user, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        public UserService GetSut()
            => new(mockUserManager.Object, mockRoleManager.Object);
    }
}
