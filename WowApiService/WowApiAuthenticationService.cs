using Microsoft.Extensions.Caching.Memory;
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
    private readonly IMemoryCache _memoryCache;
    private readonly WowApiOptions _wowApiOptions;
    private readonly MemoryCacheEntryOptions _cacheOptions;
    private const string CacheKey = "WowApiAccessToken";
    public WowApiAuthenticationService(HttpClient httpClient, IOptions<WowApiOptions> options, IMemoryCache memoryCache)
    {
        _httpClient = httpClient;
        _memoryCache = memoryCache;
        _wowApiOptions = options.Value;

        _cacheOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24)
        };
    }

    public async Task<string> GetAccessTokenAsync()
    {
        if (_memoryCache.TryGetValue(CacheKey, out string accessToken))
        {
            return accessToken;
        }

        var oAuthToken = await GetOAuthTokenAsync();

        _memoryCache.Set(CacheKey, oAuthToken.AccessToken);

        return oAuthToken.AccessToken;
    }

    private async Task<OAuthTokenDto> GetOAuthTokenAsync()
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
