namespace Guild.Manager.Infrastructure.Options;

public record ConnectionStrings
{
    public const string Section = "ConnectionStrings";
    public string Postgres { get; init; }
}
