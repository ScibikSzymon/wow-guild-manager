namespace Guild.Manager.Application.Common.Responses;

public class ValidationErrorResponse : IResponse
{
    public IEnumerable<PropertyValidationErrors> ValidationError { get; set; } = [];
}

public record PropertyValidationErrors(string PropertyName, IEnumerable<string> Errors);