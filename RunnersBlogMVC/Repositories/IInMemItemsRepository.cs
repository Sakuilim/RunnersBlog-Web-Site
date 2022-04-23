using RunnersBlogMVC.Models;

namespace RunnersBlogMVC.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid Id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Guid Id);  
    }
}