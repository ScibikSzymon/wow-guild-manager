﻿using Microsoft.Extensions.DependencyInjection;
using WowApiService.Options;

namespace WowApiService;

public static class DependencyInjection
{
    public static IServiceCollection AddWowApiService(this IServiceCollection services)
    {
        services.AddHttpClient<IWowApiAuthenticationService, WowApiAuthenticationService>(httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://oauth.battle.net/");
        });
        services.AddSingleton<IWowApiService, WowApiService>();
        services.AddOptions<WowApiOptions>().BindConfiguration(WowApiOptions.Section);

        return services;
    }
}
