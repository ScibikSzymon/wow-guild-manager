namespace Guild.Manager.Application.Common.Queries;

public abstract record FilterQueryBase
{
    public string Filter { get; set; }
}
