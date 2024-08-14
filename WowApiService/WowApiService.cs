
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

    public async Task<WowCharacterDto> GetCharacter(string characterName)
    {
        var accessToken = await _wowApiAuthenticationService.GetAccessToken();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);
        var response = await _httpClient.GetAsync($"/profile/wow/character/burning-legion/{characterName}?namespace=profile-eu&locale=en_US");

        return response.StatusCode switch
        {
            HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<WowCharacterDto>(),
            _ => throw new Exception("Failed to read character from wow api")
        };
    }


}
