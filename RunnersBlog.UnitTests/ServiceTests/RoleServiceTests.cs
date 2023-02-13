using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DataAccessLayer.Models;
using System.Threading.Tasks;
using Xunit;
using RunnersBlogMVC.Services.RoleServices;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class RoleServiceTests
    {
        private readonly Mock<UserManager<User>> mockUserManager;
        private readonly Mock<RoleManager<IdentityRole>> mockRoleManager;

        public RoleServiceTests()
        {
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            mockRoleManager = new Mock<RoleManager<IdentityRole>>(Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);
        }

        [Fact]
        public async Task When_CreateRoleNoRole_Should_CreateRole()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                UserName = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(It.IsAny<User>());

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
                UserName = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            mockUserManager.Setup(x => x
            .AddToRoleAsync(
                It.IsAny<User>(),
                It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);

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
                UserName = "test2"
            };
            var role = UserRole.User;

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            mockUserManager.Setup(x => x
            .AddToRoleAsync(
                It.IsAny<User>(),
                It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed());

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
