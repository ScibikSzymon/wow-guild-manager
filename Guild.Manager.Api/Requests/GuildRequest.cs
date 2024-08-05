
using FluentValidation;

namespace Guild.Manager.Api.Requests;

public record GuildRequest
{
    public string Name { get; init; }
}

public class GuildRequestValidator : AbstractValidator<GuildRequest>
{
    public GuildRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
