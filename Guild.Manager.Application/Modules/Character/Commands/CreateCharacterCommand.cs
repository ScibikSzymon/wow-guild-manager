using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using MediatR;
using WowApiService;

namespace Guild.Manager.Application.Modules.Character.Commands;

public record CreateCharacterCommand(string MemeberId, string CharacterName, string Realm) : IRequest<Response<CharacterDto>>;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Response<CharacterDto>>
{
    private readonly IWowApiService _wowApiService;

    public CreateCharacterCommandHandler(IWowApiService wowApiService)
    {
        _wowApiService = wowApiService;
    }
    public async Task<Response<CharacterDto>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _wowApiService.GetCharacterAsync(request.CharacterName, request.Realm);

        return new CharacterDto
        {
            Name = result.Name,
            ActiveSpec = result.ActiveSpec.Name
        };
    }
}
