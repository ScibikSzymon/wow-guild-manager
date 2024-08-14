using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using MediatR;
using WowApiService;

namespace Guild.Manager.Application.Modules.Character.Commands;

public record CreateCharacterCommand(string MemeberId, string CharacterName) : IRequest<Response<CharacterDto>>;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Response<CharacterDto>>
{
    private readonly IWowApiService _wowApiService;

    public CreateCharacterCommandHandler(IWowApiService wowApiService)
    {
        _wowApiService = wowApiService;
    }
    public async Task<Response<CharacterDto>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        var result = await _wowApiService.GetCharacter(request.CharacterName);

        return new CharacterDto
        {
            Name = result.Name,
            ActiveSpec = result.ActiveSpec.Name
        };
    }
}
