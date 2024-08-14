
using WowApiService.Dtos;

namespace WowApiService
{
    internal interface IWowApiAuthenticationService
    {
        Task<OAuthTokenDto> GetAccessToken();
    }
}