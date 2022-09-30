using MongoDB.Driver;
using Moq;
using RunnersBlogMVC.Models;
using RunnersBlogMVC.Repositories;
using System;
using Xunit;

namespace RunnersBlog.UnitTests
{
    public class MongoDBTests
    {
        private const string databaseName = "randomDb";
        private const string collectionName = "randomCollection";
        private Mock<IMongoClient> mockMongoClient = new Mock<IMongoClient>();
        private IMongoCollection<Item> mockMongoCollection;

        //[Fact]
        //public void Test1()
        //{
        //    //Arrange
        //   // var mongoDbMock = new Mock<IMongoDatabase>();
        //    var guidMock = Guid.NewGuid();

        //    var sut = GetSut();
        //    //Act
            
        //    var result = sut.GetItemAsync(guidMock);

        //    //Assert
          

        //}

        //public MongoDbItemsRepo GetSut()
        //{
        //   return new MongoDbItemsRepo(mockMongoClient.Object);
        //}
    }
}