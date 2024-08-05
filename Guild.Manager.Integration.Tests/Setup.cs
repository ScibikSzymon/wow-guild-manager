
using Npgsql;
using Testcontainers.PostgreSql;

namespace Guild.Manager.Integration.Tests;

public class Setup 
{


    public GuildManagerWebAppFactory WebAppFactory { get; private set; }
    public Setup()
    {
        WebAppFactory = new GuildManagerWebAppFactory();
    }



}
