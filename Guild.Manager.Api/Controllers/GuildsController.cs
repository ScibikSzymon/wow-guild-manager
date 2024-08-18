using Guild.Manager.Api.Constants;
using Guild.Manager.Api.Requests;
using Guild.Manager.Api.Requests.Base;
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Modules.Guild.Commands;
using Guild.Manager.Application.Modules.Guild.Queries;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Manager.Api.Controllers;

public class GuildsController : BaseApiController
{
    [HttpGet(Routes.Guilds.GetAll)]
    public async Task<ActionResult<IEnumerable<GuildDto>>> GetAll([FromQuery] BaseFilterRequest baseFilterRequest, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(baseFilterRequest.Adapt<GetGuildsQuery>(), cancellationToken);

        return Ok(result);
    }

    [HttpGet(Routes.Guilds.GetById)]
    public async Task<ActionResult<GuildDto>> GetById(int id)
    {

        return new GuildDto();
    }

    [HttpPost(Routes.Guilds.Create)]
    public async Task<ActionResult<GuildDto>> PostGuild([FromBody] CreateGuildRequest guild, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(guild.Adapt<CreateGuildCommand>(), cancellationToken);

        return CreatedAtAction(nameof(GetById), new { guildId = result.GuildId }, result);
    }

    [HttpPut(Routes.Guilds.Update)]
    public async Task<IActionResult> Update(int id, CreateGuildRequest guild)
    {

        return NoContent();
    }

    [HttpDelete(Routes.Guilds.Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }
}

