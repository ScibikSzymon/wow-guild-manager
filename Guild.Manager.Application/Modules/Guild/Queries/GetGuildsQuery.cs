using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Queries;
using Mapster;
using MediatR;

namespace Guild.Manager.Application.Modules.Guild.Queries;

public record class GetGuildsQuery : FilterQueryBase, IRequest<IEnumerable<GuildDto>>;

public class GetGuildsQueryHandler : IRequestHandler<GetGuildsQuery, IEnumerable<GuildDto>>
{
    private readonly IGuildRepository _guildRepository;

    public GetGuildsQueryHandler(IGuildRepository guildRepository)
    {
        _guildRepository = guildRepository;
    }

    public async Task<IEnumerable<GuildDto>> Handle(GetGuildsQuery request, CancellationToken cancellationToken)
    {
        var result = await _guildRepository.GetAllAsync(cancellationToken);     

        return result.Adapt<IEnumerable<GuildDto>>();
    }
}