
namespace WowApiService
{
    public interface IWowApiAuthenticationService
    {
        Task<string> GetAccessToken();
    }
}