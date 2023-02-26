namespace DataAccessLayer.Repositories.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T>(string storedProcedure, T parameters);
        Task SaveData<T>(string storedProcedure, T parameters);
    }
}