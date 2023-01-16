﻿using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using System.Threading;
using Xunit;
using RunnersBlogMVC.Services.ProfileServices;

namespace RunnersBlogMVC.UnitTests.ServiceTests
{
    public class ProfileServiceTests
    {
        private readonly Mock<IItemsRepository> mockRepo;
        private readonly Mock<UserManager<User>> mockUserManager;
        public CancellationToken cancellationToken;
        public ProfileServiceTests()
        {
            mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            this.mockRepo = new Mock<IItemsRepository>();
            cancellationToken = new CancellationToken();

        }
        [Fact]
        public void UserProfile()
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
