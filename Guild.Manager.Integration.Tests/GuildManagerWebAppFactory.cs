using Dapper;
using Guild.Manager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Testcontainers.PostgreSql;

namespace Guild.Manager.Integration.Tests;

public class GuildManagerWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly PostgreSqlContainer _postgresSqlContainer = new PostgreSqlBuilder()
        .WithImage("postgres:latest")
        .WithDatabase("wow-manage-guild-tests")
        .WithUsername("postgres")
        .WithPassword("postgres")
        .Build();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(cfgBuilder =>
        {
            cfgBuilder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { "ConnectionStrings:Postgres", _postgresSqlContainer.GetConnectionString() }
            });
        });
    }

    public async Task InitializeAsync()
    {
        await _postgresSqlContainer.StartAsync();
        var initScript = File.ReadAllText("..\\..\\..\\..\\postgres\\init\\init.sql");
        using var connection = new NpgsqlConnection(_postgresSqlContainer.GetConnectionString());
        await connection.OpenAsync();
        var command = new CommandDefinition(initScript, connection);

        await connection.ExecuteAsync(command);
    }

    public async new Task DisposeAsync()
    {
        await _postgresSqlContainer.DisposeAsync();
    }
}
