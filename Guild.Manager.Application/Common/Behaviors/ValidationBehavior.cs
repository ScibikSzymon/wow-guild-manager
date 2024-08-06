using FluentValidation;
using Guild.Manager.Application.Common.Responses;
using MediatR;

namespace Guild.Manager.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : IResponse
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {

        if (!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);
        var result = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(request, cancellationToken)));

        return Va
    }
}
