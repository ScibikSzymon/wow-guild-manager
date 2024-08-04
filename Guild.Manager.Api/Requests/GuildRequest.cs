
using FluentValidation;

namespace Guild.Manager.Api.Requests;

public class GuildRequest
{
    public string Name { get; set; }
}

public class GuildRequestValidator : AbstractValidator<GuildRequest>
{
    public GuildRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
