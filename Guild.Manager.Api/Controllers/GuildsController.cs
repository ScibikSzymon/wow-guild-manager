using Guild.Manager.Api.Constants;
using Guild.Manager.Api.Requests;
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Modules.Guild;
using Guild.Manager.Application.Modules.Guild.Commands;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Manager.Api.Controllers;

public class GuildsController : BaseApiController
{
    private readonly IMediator _mediator;

    public GuildsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Routes.Guilds.GetAll)]
    public async Task<ActionResult<IEnumerable<GuildDto>>> GetGuilds()
    {
        return new GuildDto[2];
    }

    [HttpGet(Routes.Guilds.GetById)]
    public async Task<ActionResult<GuildDto>> GetGuild(int id)
    {

        return new GuildDto();
    }

    [HttpPost(Routes.Guilds.Create)]
    public async Task<ActionResult<GuildDto>> PostGuild([FromBody] GuildRequest guild, CancellationToken cancellationToken)
    {
        //var result = await _guildService.CreateGuildAsync(guild.Adapt<GuildDto>(), cancellationToken);
        var result = await _mediator.Send(guild.Adapt<CreateGuildCommand>());

        return CreatedAtAction(nameof(GetGuild), new { guildId = result.GuildId }, guild);
    }

    [HttpPut(Routes.Guilds.Update)]
    public async Task<IActionResult> PutGuild(int id, GuildRequest guild)
    {

        return NoContent();
    }

    [HttpDelete(Routes.Guilds.Delete)]
    public async Task<IActionResult> DeleteGuild(int id)
    {
        return NoContent();
    }
}

