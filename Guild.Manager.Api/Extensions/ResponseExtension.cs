using Guild.Manager.Application.Common.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Guild.Manager.Api.Extensions;

public static class ResponseExtension
{
    public static ActionResult ToApiReposne<T0>(this Response<T0> response, HttpContext httpContext) where T0 : ISuccessReponse
    {
        return response.Value switch
        {
            ISuccessCreateResponse r => new CreatedResult($"{httpContext.Request.Path}/{r.Id}", r),
            ISuccessReponse r => new OkObjectResult(r),
            ValidationErrorResponse r => new UnprocessableEntityObjectResult(r.ValidationError),
            _ => new BadRequestObjectResult("Server can't process the request.")
        };
    }

}

