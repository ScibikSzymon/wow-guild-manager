namespace Guild.Manager.Application.Modules.Guild;

public interface IGuildRepository
{
    Task CreateGuild();
    Task GetGuild(string guildname);
}
