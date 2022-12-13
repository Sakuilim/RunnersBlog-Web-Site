using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using RunnersBlogMVC.Services.LoginServices;
using RunnersBlogMVC.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class ProfileServiceTests
    {
        private readonly Mock<IItemsRepository> mockRepo;
        private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
        public CancellationToken cancellationToken;
        public ProfileServiceTests()
        {
            mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            this.mockRepo = new Mock<IItemsRepository>();
            cancellationToken = new CancellationToken();

        }
        [Fact]
        public void Test1()
        {
            //Arrange
            var email = "test@test.com";

            var sut = GetSut();
            //Act
            var result = sut.UserProfileAsync(email, cancellationToken);

            //Assert
            result.Should().NotBeNull();
        }
        public ProfileService GetSut()
        => new(mockRepo.Object, mockUserManager.Object);
    }
}
