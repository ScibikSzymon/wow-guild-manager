namespace Guild.Manager.Api.Requests;

public record CreateCharacterRequest
{
    public string MemberID { get; init; }
    public string CharacterName { get; init; }
    public string Realm { get; init; }
}

