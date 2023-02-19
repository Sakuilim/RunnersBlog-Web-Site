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
    => await _db.LoadData<Item, dynamic>(
        "dbo.usp_ItemGetAll",
        new { });
    public async Task<Item?> GetItem(Guid id)
    {
        var results = await _db.LoadData<Item, dynamic>(
            "dbo.usp_ItemGet",
            new { Id = id });
        return results.FirstOrDefault();
    }
    public async Task InsertItem(Item item)
    => await _db.SaveData(
            "dbo.usp_ItemInsert",
            new { });
    public async Task UpdateItem(Item item)
    => await _db.SaveData(
            "dbo.usp_ItemUpdate",
            item);
    public async Task DeleteItem(Guid id)
    => await _db.SaveData("dbo.usp_ItemDelete",
            new { Id = id });
}
