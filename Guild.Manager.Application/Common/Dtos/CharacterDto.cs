using Guild.Manager.Application.Common.Responses;

namespace Guild.Manager.Application.Common.Dtos;

public record CharacterDto : ISuccessCreateResponse
{
    public int CharacterId { get; init; }
    public int MemberId { get; init; }
    public string CharacterName { get; init; }

    int ISuccessCreateResponse.Id => CharacterId;
}
