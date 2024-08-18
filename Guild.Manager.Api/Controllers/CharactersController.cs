using Guild.Manager.Api.Constants;
using Guild.Manager.Api.Requests.Base;
using Guild.Manager.Api.Requests;
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Modules.Guild.Queries;
using Microsoft.AspNetCore.Mvc;
using Guild.Manager.Application.Modules.Character.Commands;
using Mapster;
using Guild.Manager.Api.Extensions;

namespace Guild.Manager.Api.Controllers;

public class CharactersController : BaseApiController
{
    [HttpGet(Routes.Character.GetAll)]
    public async Task<ActionResult<IEnumerable<GuildDto>>> GetAll([FromQuery] BaseFilterRequest baseFilterRequest, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(baseFilterRequest.Adapt<GetGuildsQuery>(), cancellationToken);

        return Ok(result);
    }

    [HttpGet(Routes.Character.GetById)]
    public async Task<ActionResult<GuildDto>> GetById(int id)
    {

        return new GuildDto();
    }

    [HttpPost(Routes.Character.Create)]
    public async Task<ActionResult<GuildDto>> PostGuild([FromBody] CreateCharacterRequest memmberRequest, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(memmberRequest.Adapt<CreateCharacterCommand>(), cancellationToken);

        return result.ToApiReposne(HttpContext);
    }

    [HttpPut(Routes.Character.Update)]
    public async Task<IActionResult> Update(int id, CreateGuildRequest guild)
    {

        return NoContent();
    }

    [HttpDelete(Routes.Character.Delete)]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }
}
