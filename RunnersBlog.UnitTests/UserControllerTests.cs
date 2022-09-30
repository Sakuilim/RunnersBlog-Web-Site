using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests
{
    public class UserControllerTests
    {

        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        private readonly Mock<RoleManager<ApplicationRole>> mockRoleManager;

        public UserControllerTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            mockRoleManager = new Mock<RoleManager<ApplicationRole>>(Mock.Of<IRoleStore<ApplicationRole>>(), null, null, null, null);
        }

        [Fact]
        public void UserPage_Should_ReturnDefaultView() 
        {
            //Arrange
            var controller = new UserController(
                It.IsAny<UserManager<ApplicationUser>>(),
                It.IsAny<RoleManager<ApplicationRole>>());

            //Act

            var result = controller.CreateUser();

            //Assert

            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
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
             var result = await sut.CreateUser(user);

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
                Name = "test2"
            };

            mockUserManager.Setup(x => x
            .CreateAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
            .Returns(Task.FromResult(IdentityResult.Failed()));

            var sut = GetSut();

            //Act
            var result = await sut.CreateUser(user);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        public UserController GetSut()
            => new(mockUserManager.Object, mockRoleManager.Object);
    }
}
