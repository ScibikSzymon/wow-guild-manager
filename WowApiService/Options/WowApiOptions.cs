namespace WowApiService.Options;

public record WowApiOptions
{
    public const string Section = "WowApi";
    public string ClientSecret { get; init; }
    public string ClientId { get; init; }
}
