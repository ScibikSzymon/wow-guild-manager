using System.Text.Json.Serialization;

namespace WowApiService.Dtos;

public record WowCharacterDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("active_spec")]
    public ActiveSpec ActiveSpec { get; init; }
}

public record ActiveSpec
{
    [JsonPropertyName("name")]
    public string Name { get; init; }
}