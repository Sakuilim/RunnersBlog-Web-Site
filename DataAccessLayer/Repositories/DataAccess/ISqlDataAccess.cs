namespace DataAccessLayer.Repositories.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T>(string storedProcedure);
        Task SaveData<T>(string storedProcedure);
    }
}