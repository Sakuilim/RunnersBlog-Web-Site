using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services.LoginServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class LoginServiceTests
    {
        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        private readonly Mock<SignInManager<ApplicationUser>> mockSignInManager;

        public LoginServiceTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            mockSignInManager = new Mock<SignInManager<ApplicationUser>>(mockUserManager.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(), null, null, null, null);
        }
        [Fact]
        public void Login()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com"
            };
            user.Password = "Test";

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(user.Email, user.Password);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Login_UserExistsWrongPassword()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Password = "Test"
        };

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(new ApplicationUser()));

            mockSignInManager.Setup(x => x
            .PasswordSignInAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                false,
                false))
            .Returns(Task.FromResult(SignInResult.Failed));

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(user.Email, user.Password);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Login_UserExistsCorrectPassword()
        {
            //Arrange
            var user = new User
            {
                Email = "email@email.com",
                Password = "Test"
            };

            mockUserManager.Setup(x => x
            .FindByEmailAsync(
                It.IsAny<string>()))
            .Returns(Task.FromResult(new ApplicationUser()));

            mockSignInManager.Setup(x => x
            .PasswordSignInAsync(
                It.IsAny<ApplicationUser>(),
                It.IsAny<string>(),
                false,
                false))
            .Returns(Task.FromResult(SignInResult.Success));

            var sut = GetSut();
            //Act
            var result = sut.LoginUser(user.Email, user.Password);

            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void Logout()
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
