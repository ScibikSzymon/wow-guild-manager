using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Domain.Entities;
using Mapster;
using MediatR;
using WowApiService;

namespace Guild.Manager.Application.Modules.Guild.Commands;

public record CreateGuildCommand(string Name, string Realm) : IRequest<GuildDto>;

public class CreateGuildCommandHandler : IRequestHandler<CreateGuildCommand, GuildDto>
{
    private readonly IGuildRepository _guildRepository;
    private readonly IWowApiService _wowApiService;

    public CreateGuildCommandHandler(IGuildRepository guildRepository, IWowApiService wowApiService)
    {
        _guildRepository = guildRepository;
        _wowApiService = wowApiService;
    }

    public async Task<GuildDto> Handle(CreateGuildCommand request, CancellationToken cancellationToken)
    {
        var wowGuild = await _wowApiService.GetGuildAsync(request.Name, request.Realm); //TODO: use this later to extract emblem, for now I make sure this guild exist

        var guild = request.Adapt<GuildEntity>();
        guild.CreateDate = DateTime.UtcNow;

        var result = await _guildRepository.InsertAsync(guild, cancellationToken);

        return result.Adapt<GuildDto>();
    }
}
