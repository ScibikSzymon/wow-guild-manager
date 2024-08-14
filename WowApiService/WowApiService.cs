
using System.Net.Http.Headers;

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

    public async Task GetCharacter(string characterName)
    {
        var accessToken = await _wowApiAuthenticationService.GetAccessToken();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.AccessToken);

        var response = await _httpClient.GetAsync("data/wow/token/?namespace=dynamic-eu");

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
    }


}
