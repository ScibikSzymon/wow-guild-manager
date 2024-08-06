using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Domain.Entities;
using Mapster;
using MediatR;

namespace Guild.Manager.Application.Modules.Guild.Commands;

public record CreateGuildCommand(string Name) : IRequest<GuildDto>;

public class CreateGuildCommandHandler : IRequestHandler<CreateGuildCommand, GuildDto>
{
    private readonly IGuildRepository _guildRepository;

    public CreateGuildCommandHandler(IGuildRepository guildRepository)
    {
        _guildRepository = guildRepository;
    }

    public async Task<GuildDto> Handle(CreateGuildCommand request, CancellationToken cancellationToken)
    {
        var guild = request.Adapt<GuildEntity>();
        guild.CreateDate = DateTime.UtcNow;

        var result = await _guildRepository.InsertAsync(guild, cancellationToken);

        return result.Adapt<GuildDto>();
    }
}
