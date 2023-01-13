using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DataAccessLayer.Controllers;
using DataAccessLayer.Models;
using DataAccessLayer.Services.UserService;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayer.UnitTests.ServiceTests
{
    public class UserServiceTests
    {
        private readonly Mock<UserManager<User>> mockUserManager;
        private readonly Mock<RoleManager<IdentityRole>> mockRoleManager;

        public UserServiceTests()
        {
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            mockRoleManager = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
        }

        [Fact]
        public void UserPage_Should_ReturnDefaultView()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2"
            };

            var sut = GetSut();

            //Act
            var result = sut.CreateAsync(user, CancellationToken.None);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Task<IActionResult>>();
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
                It.IsAny<User>(),
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
                It.IsAny<User>(),
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
