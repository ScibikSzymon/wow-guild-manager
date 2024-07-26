namespace Guild.Manager.Application.Modules.Guild;

internal interface IGuildService
{
    Task CreateGuild();
    Task GetGuild(string guildname);
}
