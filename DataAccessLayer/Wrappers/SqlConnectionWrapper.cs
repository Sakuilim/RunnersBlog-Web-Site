using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Wrappers
{
    public class SqlConnectionWrapper : ISqlConnectionWrapper
    {
        private readonly IDbConnection _connection;

        public SqlConnectionWrapper(IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }
        public SqlConnectionWrapper(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }
        private IDbConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(connectionString);
            }

            return new SqlConnection(connectionString);
        }

        public async Task ExecuteWriterSPAsync<T>(string storedProcedureName)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            await _connection.ExecuteAsync(
                storedProcedureName,
                commandType: CommandType.StoredProcedure);

            _connection.Close();
        }

        public async Task<IEnumerable<T>> ExecuteReaderSPAsync<T>(string storedProcedureName)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return await _connection.QueryAsync<T>(
                storedProcedureName,
                commandType: CommandType.StoredProcedure);
        }
    }
}
