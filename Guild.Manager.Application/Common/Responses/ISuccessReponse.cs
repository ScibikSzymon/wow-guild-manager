namespace Guild.Manager.Application.Common.Responses;

public interface ISuccessReponse
{
}
public interface ISuccessCreateResponse : ISuccessReponse
{
    int Id { get; }
}