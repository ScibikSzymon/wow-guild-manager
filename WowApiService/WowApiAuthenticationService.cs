using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using WowApiService.Dtos;
using WowApiService.Options;

namespace WowApiService;

internal class WowApiAuthenticationService : IWowApiAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly WowApiOptions _wowApiOptions;

    public WowApiAuthenticationService(HttpClient httpClient, IOptions<WowApiOptions> options)
    {
        _httpClient = httpClient;
        _wowApiOptions = options.Value;
    }

    public async Task<OAuthTokenDto> GetAccessToken()
    {
        var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{_wowApiOptions.ClientId}:{_wowApiOptions.ClientSecret}"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        
        var content = new FormUrlEncodedContent(
        [
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        ]);

        var response = await _httpClient.PostAsync("/token", content);

        return response.StatusCode switch
        {
            HttpStatusCode.OK => await response.Content.ReadFromJsonAsync<OAuthTokenDto>(),
            _ => throw new Exception("Cloud not authenticate to wow api.")
        };
    }
}
