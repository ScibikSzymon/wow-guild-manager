using Microsoft.Extensions.DependencyInjection;
using WowApiService.Options;

namespace WowApiService;

public static class DependencyInjection
{
    public static IServiceCollection AddWowApiService(this IServiceCollection services)
    {
        services.AddSingleton<IWowApiAuthorizationService, WowApiAuthorizationService>();
        services.AddSingleton<IWowApiService, WowApiService>();
        services.AddOptions<WowApiOptions>().BindConfiguration(WowApiOptions.Section);

        return services;
    }
}
