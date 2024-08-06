using Dapper;
using Guild.Manager.Application.Modules.Members;
using Guild.Manager.Domain.Entities;

namespace Guild.Manager.Infrastructure.Persistence;

internal class MemberRepository : IMemberRepository
{
    private const string _createQuery = @"
        INSERT INTO Member (GuildId, Name, JoinDate, Role) 
        VALUES (@GuildId, @Name, @JoinDate, @Role) 
        RETURNING GuildId";

    private const string _getAllQuery = @"SELECT * FROM Member";

    private readonly PostgresContext _postgresContext;
    public MemberRepository(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }
    public Task DeleteAsync(MemberEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<MemberEntity> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<MemberEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        using var connection = _postgresContext.CreateConnection();
        var commnad = new CommandDefinition(_getAllQuery, cancellationToken: cancellationToken);
        var result = await connection.QueryAsync<MemberEntity>(commnad);

        return result;
    }

    public async Task<MemberEntity> InsertAsync(MemberEntity entity, CancellationToken cancellationToken)
    {
        using var connection = _postgresContext.CreateConnection();
        var command = new CommandDefinition(_createQuery, entity, cancellationToken: cancellationToken);
        var id = await connection.ExecuteScalarAsync<int>(command);

        entity.MemberId = id;
        return entity;
    }

    public Task<MemberEntity> UpdateAsync(MemberEntity entity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
