using Guild.Manager.Application.Common.Dtos;

namespace Guild.Manager.Application.Modules.Guild;

public interface IGuildService
{
    Task<GuildDto> CreateGuildAsync(GuildDto guildDto, CancellationToken cancellationToken = default);
    Task GetGuild(string guildname);
}
