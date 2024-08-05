﻿using Guild.Manager.Application.Modules.Guild;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Guild.Manager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return serviceCollection;
    }
}
