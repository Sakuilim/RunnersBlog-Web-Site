using DataAccessLayer.Models;

namespace DataAccessLayer.Data;

public interface IUserData
{
    Task DeleteUser(string id);
    Task<User?> GetUser(string id);
    Task<IEnumerable<User>> GetUsers();
    Task InsertUser(User user);
    Task UpdateUser(User user);
}