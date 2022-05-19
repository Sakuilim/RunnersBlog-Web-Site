using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Repositories
{
    public interface IItemsRepository
    {
        Task<Item> GetItemAsync(Guid Id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreateItemAsync(Item item);
        Task UpdateItemAsync(Item item);
        Task DeleteItemAsync(Guid Id);  
    }
}