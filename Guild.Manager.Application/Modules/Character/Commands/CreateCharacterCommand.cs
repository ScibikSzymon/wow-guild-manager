using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using MediatR;

namespace Guild.Manager.Application.Modules.Character.Commands;

public record CreateCharacterCommand(string MemeberId, string characterName) : IRequest<Response<CharacterDto>>;

public class CreateCharacterCommandHandler : IRequestHandler<CreateCharacterCommand, Response<CharacterDto>>
{
    public Task<Response<CharacterDto>> Handle(CreateCharacterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
