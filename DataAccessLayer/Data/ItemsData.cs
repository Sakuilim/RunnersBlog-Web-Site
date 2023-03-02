using DataAccessLayer.Models;
using DataAccessLayer.Models.Items;
using DataAccessLayer.Repositories.DataAccess;

namespace DataAccessLayer.Data;

public class ItemsData : IItemsData
{
    private readonly ISqlDataAccess _db;

    public ItemsData(ISqlDataAccess db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Item>> GetItems()
    => await _db.LoadData<Item>(
        "dbo.usp_ItemGetAll");
    public async Task<Item> GetItem(Guid id)
    {
        var results = await _db.LoadData<Item>(
            "dbo.usp_ItemGet");
        return results.FirstOrDefault();
    }
    public async Task InsertItem(Item item)
    => await _db.SaveData<Item>(
            "dbo.usp_ItemInsert");
    public async Task UpdateItem(Item item)
    => await _db.SaveData<Item>(
            "dbo.usp_ItemUpdate");
    public async Task DeleteItem(Guid id)
    => await _db.SaveData<Item>("dbo.usp_ItemDelete");
}
