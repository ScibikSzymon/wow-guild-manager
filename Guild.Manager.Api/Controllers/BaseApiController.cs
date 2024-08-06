using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Manager.Api.Controllers;

[ApiController]
public class BaseApiController : ControllerBase
{
    private ISender _mediator;
    protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetService<ISender>();
}
