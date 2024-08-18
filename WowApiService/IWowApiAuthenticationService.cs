
using WowApiService.Dtos;

namespace WowApiService
{
    internal interface IWowApiAuthenticationService
    {
        Task<string> GetAccessTokenAsync();
    }
}