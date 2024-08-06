using Guild.Manager.Api.Constants;
using Guild.Manager.Api.Requests.Base;
using Guild.Manager.Api.Requests;
using Guild.Manager.Application.Common.Dtos;
using Guild.Manager.Application.Modules.Guild.Commands;
using Guild.Manager.Application.Modules.Guild.Queries;
using Microsoft.AspNetCore.Mvc;
using Guild.Manager.Application.Modules.Members.Commands;
using Mapster;

namespace Guild.Manager.Api.Controllers
{
    public class MembersController : BaseApiController
    {
        [HttpGet(Routes.Members.GetAll)]
        public async Task<ActionResult<IEnumerable<GuildDto>>> GetAll([FromQuery] BaseFilterRequest baseFilterRequest, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(baseFilterRequest.Adapt<GetGuildsQuery>(), cancellationToken);

            return Ok(result);
        }

        [HttpGet(Routes.Members.GetById)]
        public async Task<ActionResult<GuildDto>> GetById(int id)
        {

            return new GuildDto();
        }

        [HttpPost(Routes.Members.Create)]
        public async Task<ActionResult<GuildDto>> PostGuild([FromBody] CreateMemberRequest memmberRequest, CancellationToken cancellationToken)
        {
            var result = await Mediator.Send(memmberRequest.Adapt<CreateMemberCommand>(), cancellationToken);

            return CreatedAtAction(nameof(GetById), new { memberId = result.MemberId }, result);
        }

        [HttpPut(Routes.Members.Update)]
        public async Task<IActionResult> Update(int id, GuildRequest guild)
        {

            return NoContent();
        }

        [HttpDelete(Routes.Members.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
