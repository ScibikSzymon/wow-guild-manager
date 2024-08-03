namespace WowApiService;

internal class WowApiAuthorizationService : IWowApiAuthorizationService
{
    public WowApiAuthorizationService(HttpClient httpClient)
    {

    }

    public Task<string> GetAccessToken()
    {
        return null;
    }
}
