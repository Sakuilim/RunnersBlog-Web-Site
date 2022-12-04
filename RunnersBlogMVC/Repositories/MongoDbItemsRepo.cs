using MongoDB.Bson;
using MongoDB.Driver;
using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Repositories
{
    public class MongoDbItemsRepo : IItemsRepository
    {
        private const string databaseName = "Catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        
        public MongoDbItemsRepo(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Item>(collectionName);
        }
        [Obsolete]
        public async Task CreateItemAsync(Item item, CancellationToken cancellationToken)
        {
            await itemsCollection.InsertOneAsync(item, cancellationToken);
        }
        public async Task DeleteItemAsync(Guid Id, CancellationToken cancellationToken)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            await itemsCollection.DeleteOneAsync(filter, cancellationToken);
        }
        public async Task<Item> GetItemAsync(Guid Id, CancellationToken cancellationToken)
        {
            var filter = filterBuilder.Eq(item => item.Id, Id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync(cancellationToken);
        }
        public async Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken)
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync(cancellationToken);
        }
        public async Task UpdateItemAsync(Item item, CancellationToken cancellationToken)
        {
            var filter = filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}
