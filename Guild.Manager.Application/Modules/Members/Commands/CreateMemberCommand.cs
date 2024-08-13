using FluentValidation;
using FluentValidation.Results;
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Common.Responses;
using Guild.Manager.Application.Modules.Guild;
using Guild.Manager.Domain.Entities;
using Mapster;
using MediatR;

namespace Guild.Manager.Application.Modules.Members.Commands;

public record CreateMemberCommand(int GuildId, string Name, string Role) : IRequest<Response<MemberDto>>;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Response<MemberDto>>
{
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<Response<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var model = request.Adapt<MemberEntity>();
        model.JoinDate = DateTime.UtcNow;

        var result = await _memberRepository.InsertAsync(model, cancellationToken);

        return result.Adapt<MemberDto>();
    }
}

class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator(IGuildRepository guildRepository)
    {
        RuleFor(x => x.GuildId)
            .MustAsync(async (id, ct) => await guildRepository.GetByIdAsync(id, ct) is not null)
            .WithMessage("GuildId do not exist");
    }

}