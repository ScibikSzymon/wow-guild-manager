using FluentValidation;

namespace Guild.Manager.Api.Requests;

public record CreateMemberRequest
{
    public int GuildId { get; init; }
    public string Name { get; init; }
    public string Role { get; init; }
}

public class CreateMemberRequestValidator : AbstractValidator<CreateMemberRequest>
{
    public CreateMemberRequestValidator()
    {
        RuleFor(x => x.GuildId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Role).NotEmpty();
    }
}
