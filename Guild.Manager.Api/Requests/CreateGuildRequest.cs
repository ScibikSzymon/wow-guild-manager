
using FluentValidation;

namespace Guild.Manager.Api.Requests;

public record CreateGuildRequest
{
    public string Name { get; init; }
    public string Realm { get; init; }
}

public class GuildRequestValidator : AbstractValidator<CreateGuildRequest>
{
    public GuildRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Realm).NotEmpty();
    }
}
