using Dapper;
using Guild.Manager.Application.Modules.Guild;
using Guild.Manager.Domain.Entities;

namespace Guild.Manager.Infrastructure.Persistence;

internal class GuildRepository : IGuildRepository
{
    private const string _createQuery = @"
        INSERT INTO Guild (Name, CreateDate) 
        VALUES (@Name, @CreateDate) 
        RETURNING GuildId";

    private const string _getAllQuery = @"SELECT * FROM Guild";

    private const string _getById = @"SELECT * FROM Guild WHERE GuildId = @GuildID";
    
    private readonly PostgresContext _postgresContext;

    public GuildRepository(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public async Task<GuildEntity> InsertAsync(GuildEntity guild, CancellationToken cancellationToken)
    {
        using var connection = _postgresContext.CreateConnection();
        var command = new CommandDefinition(_createQuery, guild, cancellationToken: cancellationToken);
        var id = await connection.ExecuteScalarAsync<int>(command);

        guild.GuildId = id;
        return guild;
    }

    public async Task<IEnumerable<GuildEntity>> GetAllAsync(CancellationToken cancellationToken) 
    {
        using var connection = _postgresContext.CreateConnection();
        var commnad = new CommandDefinition(_getAllQuery, cancellationToken: cancellationToken);

        var result = await connection.QueryAsync<GuildEntity>(commnad);

        return result;
    }

    public Task<GuildEntity> UpdateAsync(GuildEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(GuildEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<GuildEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = _postgresContext.CreateConnection();

        var parameters = new
        {
            GuildId = id,
        };
        var command = new CommandDefinition(_getById, parameters, cancellationToken: cancellationToken);
        var result = await connection.QueryFirstOrDefaultAsync<GuildEntity>(command);

        return result;
    }
}
