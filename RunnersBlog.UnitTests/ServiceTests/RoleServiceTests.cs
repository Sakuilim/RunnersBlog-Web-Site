using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Services;
using RunnersBlogMVC.Services.RoleServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class RoleServiceTests
    {
        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        private readonly Mock<RoleManager<ApplicationRole>> mockRoleManager;

        public RoleServiceTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            mockRoleManager = new Mock<RoleManager<ApplicationRole>>(Mock.Of<IRoleStore<ApplicationRole>>(), null, null, null, null);
        }

        [Fact]
        public async Task When_CreateRoleNoRole_Should_CreateRole()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(It.IsAny<ApplicationUser>()));

            var sut = GetSut();

            //Act
            var result = await sut.CreateRole(user.Email, role);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task When_CreateRoleSucessToAdd_ShouldReturnSuccess()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(It.IsAny<ApplicationUser>()));

            mockUserManager.Setup(x => x
            .AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
            .Returns(Task.FromResult(IdentityResult.Success));

            var sut = GetSut();

            //Act
            var result = await sut.CreateRole(user.Email, role);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task When_CreateRoleFailToAdd_ShouldReturnFailure()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Name = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(It.IsAny<ApplicationUser>()));

            mockUserManager.Setup(x => x
            .AddToRoleAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>()))
            .Returns(Task.FromResult(IdentityResult.Failed()));

            var sut = GetSut();

            //Act
            var result = await sut.CreateRole(user.Email, role);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        public RoleService GetSut()
        => new(mockUserManager.Object, mockRoleManager.Object);
    }
}
