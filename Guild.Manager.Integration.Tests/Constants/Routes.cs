namespace Guild.Manager.Integration.Tests.Constants;

public static class Routes
{
    public const string Base = "/api";

    public static class Guilds
    {
        public const string Base = Routes.Base + "/guilds";
        public const string BaseById = Routes.Base + Base + "{guildId}";

        public const string GetAll = Base;
        public const string GetById = BaseById;
        public const string Create = Base;
        public const string Delete = BaseById;
        public const string Update = BaseById;
    }
}

