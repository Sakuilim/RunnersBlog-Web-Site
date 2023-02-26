using Dapper;
using DataAccessLayer.Models.Items;
using DataAccessLayer.Repositories.DataAccess;
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
        private readonly Mock<IConfiguration> configuration = new Mock<IConfiguration>();
        private readonly Mock<IDbConnection> mockDbConnection;
        private readonly Mock<SqlConnection> mockSqlConnection;
        public SqlDataAccessTests()
        {
            mockSqlConnection = new Mock<SqlConnection>();
            configuration.Setup(x => x.GetConnectionString(It.IsAny<string>())).Returns(It.IsAny<string>());
            mockDbConnection = new Mock<IDbConnection>(); 
        }
        [Fact]
        public async Task LoadData_Should_ReturnData()
        {
            //Arrange
            var sut = GetSut();

            var mockItem = new List<Item>
            {
                new Item()
            };

            mockSqlConnection.Setup(x => x.)

            mockDbConnection.SetupDapperAsync(x => x.QueryAsync<Item>(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<IDbTransaction>(),
                It.IsAny<int?>(),
                It.IsAny<CommandType?>()))
                .ReturnsAsync(mockItem);

            //Act
            var result = await sut.LoadData<Item, dynamic>("db.fakeusp", new { });

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

            mockDbConnection.SetupDapperAsync(x => x.ExecuteAsync(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<IDbTransaction>(),
                It.IsAny<int?>(),
                It.IsAny<CommandType?>()));

            //Act
            await sut.SaveData("db.fakesaveusp", mockItem);

            //Assert
            mockDbConnection.Verify(x => x.ExecuteAsync(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<IDbTransaction>(),
                It.IsAny<int?>(),
                It.IsAny<CommandType?>()),
                Times.Once);
        }
        public SqlDataAccess GetSut()
            => new(configuration.Object);
    }

}
