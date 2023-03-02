using Dapper;
using DataAccessLayer.Models.Items;
using DataAccessLayer.Repositories.DataAccess;
using DataAccessLayer.Wrappers;
using FluentAssertions;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Dapper;
using System.Data;
using Xunit;

namespace DataAccessLayer.UnitTests.DataAcessTests
{
    public class SqlDataAccessTests
    {
        private readonly Mock<IConfiguration> configuration;
        private readonly Mock<IDbConnection> mockDbConnection;
        private readonly Mock<ISqlConnectionWrapper> mockSqlConnectionWrapper;
        public SqlDataAccessTests()
        {
            configuration = new Mock<IConfiguration>();
            mockDbConnection = new Mock<IDbConnection>(); 
            mockSqlConnectionWrapper = new Mock<ISqlConnectionWrapper>();
        }
        [Fact]
        public async Task LoadData_Should_ReturnData()
        {
            //Arrange
            var sut = GetSut();

            var mockItem = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid()
                }
            };

            mockSqlConnectionWrapper.Setup(x => x.ExecuteReaderSPAsync<Item>(It.IsAny<string>()))
                .ReturnsAsync(mockItem);

            //Act
            var result = await sut.LoadData<Item>("db.fakeusp");

            //Assert
            result.Should().Contain(result);
        }
        [Fact]
        public async Task SaveData_Should_SaveData()
        {
            //Arrange
            var sut = GetSut();

            var mockItem = new Item();

            var mockItems = new List<Item>
            {
                mockItem
            };

            mockSqlConnectionWrapper.Setup(x => x.ExecuteWriterSPAsync<Item>(It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            //Act
            await sut.SaveData<Item>("db.fakesaveusp");

            //Assert
            mockSqlConnectionWrapper.Verify(x => x.ExecuteWriterSPAsync<Item>(
                It.IsAny<string>()),
                Times.Once);
        }
        public SqlDataAccess GetSut()
            => new(configuration.Object,
                  mockSqlConnectionWrapper.Object);
    }

}
