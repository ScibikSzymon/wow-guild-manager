using Guild.Manager.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace Guild.Manager.Infrastructure.Persistence;

public class PostgresContext
{
    private readonly string _connectionString;

    public PostgresContext(IOptions<ConnectionStrings> connectionStrings)
    {
        _connectionString = connectionStrings.Value.Postgres;   
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
