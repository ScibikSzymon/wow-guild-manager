using Guild.Manager.Application.Modules.Guild;
using Guild.Manager.Application.Modules.Members;
using Guild.Manager.Infrastructure.Options;
using Guild.Manager.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Guild.Manager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<PostgresContext>();

        serviceCollection.TryAddScoped<IGuildRepository, GuildRepository>();
        serviceCollection.TryAddScoped<IMemberRepository, MemberRepository>();

        serviceCollection.AddOptions<ConnectionStrings>().BindConfiguration(ConnectionStrings.Section);

        return serviceCollection;
    }
}
