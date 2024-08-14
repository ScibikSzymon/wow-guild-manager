using Guild.Manager.Application.Modules.Guild;
using Guild.Manager.Application.Modules.Members;
using Guild.Manager.Infrastructure.Options;
using Guild.Manager.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WowApiService;

namespace Guild.Manager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<PostgresContext>();

        services.TryAddScoped<IGuildRepository, GuildRepository>();
        services.TryAddScoped<IMemberRepository, MemberRepository>();

        services.AddOptions<ConnectionStrings>().BindConfiguration(ConnectionStrings.Section);

        services.AddWowApiService();

        return services;
    }
}
