
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using WowApiService.Dtos;

namespace WowApiService;

internal class WowApiService : IWowApiService
{
    private readonly HttpClient _httpClient;
    private readonly IWowApiAuthenticationService _wowApiAuthenticationService;

    public WowApiService(HttpClient httpClient, IWowApiAuthenticationService wowApiAuthenticationService)
    {
        _httpClient = httpClient;
        _wowApiAuthenticationService = wowApiAuthenticationService;
    }

    public async Task<WowCharacterDto> GetCharacterAsync(string characterName, string realm, CancellationToken cancellationToken)
    {
        var accessToken = await _wowApiAuthenticationService.GetAccessTokenAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await _httpClient.GetAsync($"/profile/wow/character/{realm}/{characterName}?namespace=profile-eu&locale=en_US", cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<WowCharacterDto>(),
            _ => throw new Exception("Failed to read character from wow api")
        };
    }

    public async Task<WowGuildDto> GetGuildAsync(string guildName, string realm, CancellationToken cancellationToken)//burning-legion
    {
        var accessToken = await _wowApiAuthenticationService.GetAccessTokenAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await _httpClient.GetAsync($"/profile/wow/guild/{realm}/{guildName}?namespace=profile-eu&locale=en_US", cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<WowGuildDto>(),
            _ => throw new Exception("Failed to read character from wow api")
        };
    }
}
