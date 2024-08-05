using Dapper;
using Guild.Manager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Respawn;
using System.Data.Common;
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

    private DbConnection _connection = default;
    private Respawner _respawner = default;

    public HttpClient HttpClient { get; private set; } = default;
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

    public async Task ResetDb()
    {
        await _respawner.ResetAsync(_connection.ConnectionString);
    }

    public async Task InitializeAsync()
    {
        await _postgresSqlContainer.StartAsync();
        await InitDb();

        _connection = new NpgsqlConnection(_postgresSqlContainer.GetConnectionString());
        HttpClient = CreateClient();
        await InitRespawner();
    }

    private async Task InitRespawner()
    {
        await _connection.OpenAsync();
        _respawner = await Respawner.CreateAsync(_connection, new RespawnerOptions
        {
            DbAdapter = DbAdapter.Postgres,
            SchemasToInclude = new[] { "public" }
        });
    }

    public async new Task DisposeAsync()
    {
        await _postgresSqlContainer.DisposeAsync();
    }

    private async Task InitDb()
    {
        var initScript = File.ReadAllText("..\\..\\..\\..\\postgres\\init\\init.sql");
        using var connection = new NpgsqlConnection(_postgresSqlContainer.GetConnectionString());
        await connection.OpenAsync();
        var command = new CommandDefinition(initScript, connection);

        await connection.ExecuteAsync(command);
    }
}
