using FluentValidation;
using Guild.Manager.Application.Common.Responses;
using MediatR;
using OneOf;

namespace Guild.Manager.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
    where TResponse : IOneOf
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
        
        var validationErrors = result
            .SelectMany(x => x.Errors)
            .GroupBy(z => z.PropertyName)
            .Select(y => new PropertyValidationErrors(y.Key, y.Select(u => u.ErrorMessage)));

        if (validationErrors.Any())
        {
            var errorResponse = new ValidationErrorResponse() { ValidationError = validationErrors };

            var method = typeof(TResponse).GetMethod("FromT1");
            var @delegate = method.CreateDelegate(typeof(Func<IErrorResponse, TResponse>));

            return ((Func<IErrorResponse, TResponse>)@delegate)(errorResponse);
        }

        return await next();
    }
}
