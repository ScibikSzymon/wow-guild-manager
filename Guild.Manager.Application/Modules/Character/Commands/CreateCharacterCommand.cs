using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using MediatR;
using WowApiService;

namespace Guild.Manager.Application.Modules.Character.Commands;

public record CreateCharacterCommand(string MemeberId, string characterName) : IRequest<Response<CharacterDto>>;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Response<CharacterDto>>
{
    private readonly IWowApiService _wowApiService;

    public CreateCharacterCommandHandler(IWowApiService wowApiService)
    {
        _wowApiService = wowApiService;
    }
    public Task<Response<CharacterDto>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        _wowApiService.GetCharacter("wd");
        throw new NotImplementedException();
    }
}
