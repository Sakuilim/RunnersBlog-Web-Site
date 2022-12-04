using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using RunnersBlogMVC.Controllers;
using RunnersBlogMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
