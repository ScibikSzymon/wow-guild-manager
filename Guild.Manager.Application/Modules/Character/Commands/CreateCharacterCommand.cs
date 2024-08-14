using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using MediatR;
using WowApiService;

namespace Guild.Manager.Application.Modules.Character.Commands;

public record CreateCharacterCommand(string MemeberId, string characterName) : IRequest<Response<CharacterDto>>;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Response<CharacterDto>>
{
    private readonly IWowApiAuthenticationService _wowApiAuthenticationService;

    public CreateCharacterCommandHandler(IWowApiAuthenticationService wowApiAuthenticationService)
    {
        _wowApiAuthenticationService = wowApiAuthenticationService;
    }
    public Task<Response<CharacterDto>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        _wowApiAuthenticationService.GetAccessToken();
        throw new NotImplementedException();
    }
}
