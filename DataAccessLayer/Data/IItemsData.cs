using DataAccessLayer.Models.Items;

namespace DataAccessLayer.Data;

public interface IItemsData
{
    Task DeleteItem(Guid id);
    Task<Item?> GetItem(Guid id);
    Task<IEnumerable<Item>> GetItems();
    Task InsertItem(Item item);
    Task UpdateItem(Item item);
}