using DataAccessLayer.Wrappers;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Repositories.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;
    private readonly ISqlConnectionWrapper _sqlConnectionWrapper;
    public SqlDataAccess(IConfiguration configuration, ISqlConnectionWrapper sqlConnectionWrapper)
    {
        _configuration = configuration;
        _sqlConnectionWrapper = sqlConnectionWrapper;
    }

    public async Task<IEnumerable<T>> LoadData<T>(
        string storedProcedure,
        T parameters)
    {
        return await _sqlConnectionWrapper.ExecuteReaderSPAsync(storedProcedure, parameters);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters)
    {
        await _sqlConnectionWrapper.ExecuteWriterSPAsync(storedProcedure, parameters);
    }
}
