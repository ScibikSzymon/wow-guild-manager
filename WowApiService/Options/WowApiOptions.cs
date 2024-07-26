namespace WowApiService.Options;

public record WowApiOptions
{
    public string ClientSecret { get; init; }
    public string ClientId { get; init; }
}
