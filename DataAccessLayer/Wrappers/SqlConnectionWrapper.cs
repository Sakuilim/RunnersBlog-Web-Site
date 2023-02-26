using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Wrappers
{
    public class SqlConnectionWrapper : ISqlConnectionWrapper
    {
        private readonly SqlConnection _connection;

        public SqlConnectionWrapper(string connectionString)
        {
            _connection = CreateConnection(connectionString);
        }
        private SqlConnection CreateConnection(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(connectionString);
            }

            return new SqlConnection(connectionString);
        }

        public async Task ExecuteWriterSPAsync<T>(string storedProcedureName, T parameters)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            await _connection.ExecuteAsync(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure);

            _connection.Close();
        }

        public async Task<IEnumerable<T>> ExecuteReaderSPAsync<T>(string storedProcedureName, T parameters)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            return await _connection.QueryAsync<T>(
                storedProcedureName,
                parameters,
                commandType: CommandType.StoredProcedure);
        }
    }
}
