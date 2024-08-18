using System.Text.Json.Serialization;

namespace WowApiService.Dtos;
public class WowGuildDto
{
    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("member_count")]
    public int ActiveSpec { get; init; }
}

