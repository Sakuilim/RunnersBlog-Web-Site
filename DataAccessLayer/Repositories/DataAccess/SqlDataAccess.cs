﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DataAccessLayer.Repositories.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _configuration;
    public SqlDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "DefaultConnection")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(
            storedProcedure,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "DefaultConnection")
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedProcedure,
                                parameters,
                                commandType: CommandType.StoredProcedure);
    }
}
