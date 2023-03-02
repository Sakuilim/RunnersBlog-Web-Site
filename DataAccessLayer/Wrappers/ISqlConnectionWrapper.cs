using Microsoft.Data.SqlClient;

namespace DataAccessLayer.Wrappers
{
    public interface ISqlConnectionWrapper
    {
        Task ExecuteWriterSPAsync<T>(string storedProcedureName);
        Task<IEnumerable<T>> ExecuteReaderSPAsync<T>(string storedProcedureName);
    }
}