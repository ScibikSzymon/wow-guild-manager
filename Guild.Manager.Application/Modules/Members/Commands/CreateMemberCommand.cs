﻿using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Domain.Entities;
using Mapster;
using MediatR;

namespace Guild.Manager.Application.Modules.Members.Commands;

public record CreateMemberCommand(int GuildId, string Name, string Role) : IRequest<MemberDto>;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, MemberDto>
{
    private readonly IMemberRepository _memberRepository;

    public CreateMemberCommandHandler(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<MemberDto> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var model = request.Adapt<MemberEntity>();
        model.JoinDate = DateTime.UtcNow;

        var result = await _memberRepository.InsertAsync(model, cancellationToken);

        return result.Adapt<MemberDto>();
    }
}