using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using DataAccessLayer.Models;
using System.Threading.Tasks;
using Xunit;
using RunnersBlogMVC.Services.LoginServices;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class LoginServiceTests
    {
        private readonly Mock<UserManager<User>> mockUserManager;
        private readonly Mock<SignInManager<User>> mockSignInManager;

        public LoginServiceTests()
        {
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            mockSignInManager = new Mock<SignInManager<User>>(mockUserManager.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<User>>(), null, null, null, null);
        }
        [Fact]
        public void Login_EmailDoesntExist()
        {
            //Arrange

            var loginModel = new LoginViewModel()
            {
                Email = "email@email.com",
                Password = "Test"
            };

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(loginModel);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Login_UserExistsWrongPassword()
        {
            //Arrange
            var loginModel = new LoginViewModel()
            {
                Email = "email@email.com",
                Password = "Test"
            };

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            mockSignInManager.Setup(x => x
            .PasswordSignInAsync(
                It.IsAny<User>(),
                It.IsAny<string>(),
                false,
                false))
            .Returns(Task.FromResult(SignInResult.Failed));

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(loginModel);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Login_UserExistsCorrectPassword()
        {
            //Arrange
            var loginModel = new LoginViewModel()
            {
                Email = "email@email.com",
                Password = "Test"
            };


            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .ReturnsAsync(new User());

            mockSignInManager.Setup(x => x
            .PasswordSignInAsync(
                It.IsAny<User>(),
                It.IsAny<string>(),
                false,
                false))
            .Returns(Task.FromResult(SignInResult.Success));

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(loginModel);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Logout_ShouldReturnLogout()
        {
            //Arrange
            var sut = GetSut();
            //Act
            var result = sut.LogoutUser();
            //Assert
            result.Should().NotBeNull();
        }
        public LoginService GetSut()
            => new(mockUserManager.Object, mockSignInManager.Object);
    }
}
