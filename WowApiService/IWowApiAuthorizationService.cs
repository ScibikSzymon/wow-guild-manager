
namespace WowApiService
{
    internal interface IWowApiAuthorizationService
    {
        Task<string> GetAccessToken();
    }
}