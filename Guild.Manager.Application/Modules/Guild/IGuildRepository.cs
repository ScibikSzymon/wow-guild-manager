using Guild.Manager.Domain.Entities;

namespace Guild.Manager.Application.Modules.Guild;
public interface IGuildRepository
{
    Task<GuildEntity> CreateGuildAsync(GuildEntity guild, CancellationToken cancellationToken = default);
    Task GetGuild(string guildname);
    Task<IEnumerable<GuildEntity>> GetAll(CancellationToken cancellationToken = default);
}
