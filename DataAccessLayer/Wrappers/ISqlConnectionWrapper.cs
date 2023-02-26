using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Wrappers
{
    public interface ISqlConnectionWrapper
    {
        Task ExecuteWriterSPAsync<T>(string storedProcedureName, T parameters);
        Task<IEnumerable<T>> ExecuteReaderSPAsync<T>(string storedProcedureName, T parameters);
    }
}