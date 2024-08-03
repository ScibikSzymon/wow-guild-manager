using Guild.Manager.Application.Modules.Guild;
using Microsoft.Extensions.DependencyInjection;

namespace Guild.Manager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGuildService, GuildService>();

        return serviceCollection;
    }
}
