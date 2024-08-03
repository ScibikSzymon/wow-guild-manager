
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Domain.Entities;
using Mapster;

namespace Guild.Manager.Application.Modules.Guild;

public class GuildService : IGuildService
{
    private readonly IGuildRepository _guildRepository;

    public GuildService(IGuildRepository guildRepository)
    {
        _guildRepository = guildRepository;
    }

    public async Task<GuildDto> CreateGuildAsync(GuildDto guild, CancellationToken cancellationToken)
    {
        guild.CreateDate = DateTime.UtcNow;

        var result = await _guildRepository.CreateGuildAsync(guild.Adapt<GuildEntity>(), cancellationToken);

        return result.Adapt<GuildDto>();
    }

    public Task GetGuild(string guildname)
    {
        throw new NotImplementedException();
    }
}
