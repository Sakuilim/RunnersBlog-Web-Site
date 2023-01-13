using DataAccessLayer.Models.Items;

namespace DataAccessLayer.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid Id, CancellationToken cancellationToken);
        Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken);
        Task CreateItemAsync(Item item, CancellationToken cancellationToken);
        Task UpdateItemAsync(Item item, CancellationToken cancellationToken);
        Task DeleteItemAsync(Guid Id, CancellationToken cancellationToken);  
    }
}