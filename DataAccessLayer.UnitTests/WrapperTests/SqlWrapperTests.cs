using Dapper;
using DataAccessLayer.Models.Items;
using DataAccessLayer.Wrappers;
using FluentAssertions;
using Moq;
using Moq.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayer.UnitTests.WrapperTests
{
    public class SqlWrapperTests
    {
        private readonly Mock<IDbConnection> mockDbConnection;
        private readonly Mock<ISqlConnectionWrapper> mockSqlConnectionWrapper;
        private const string fakeConnString = "DefaultConnection";
        public SqlWrapperTests()
        {
            mockSqlConnectionWrapper = new Mock<ISqlConnectionWrapper>();
            mockDbConnection = new Mock<IDbConnection>();
        }

        [Fact]
        public async Task IDBTEST()
        {
            //Arrange

            mockDbConnection.SetupDapperAsync(x => x.ExecuteAsync(
                It.IsAny<string>(),
                It.IsAny<object>(),
                It.IsAny<IDbTransaction>(),
                It.IsAny<int?>(),
                It.IsAny<CommandType?>()));

            var sut = GetSut();

            //Act

            var act = async () => await sut.ExecuteWriterSPAsync<Item>("usp_fakeusp");

            var record = await Record.ExceptionAsync(act);

            //Assert
            record.Should().BeNull();
        }

        public SqlConnectionWrapper GetSut()
            => new(mockDbConnection.Object);
    }
}
