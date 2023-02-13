using DataAccessLayer.Models;
using DataAccessLayer.Repositories.DataAccess;

namespace DataAccessLayer.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<User>> GetUsers()
    => _db.LoadData<User, dynamic>(
        "dbo.usp_UserGetAll",
        new { });

    public async Task<User?> GetUser(string id)
    {
        var results = await _db.LoadData<User, dynamic>(
            "dbo.usp_UserGet",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertUser(User user)
    => _db.SaveData(
            "dbo.usp_UserInsert",
            new { user.UserName, user.Email, user.Password, user.Role });

    public Task UpdateUser(User user) 
    => _db.SaveData(
            "dbo.usp_UserUpdate",
            user);

    public Task DeleteUser(string id) 
    => _db.SaveData("dbo.usp_UserDelete",
            new { Id = id });

}
