using OneOf;

namespace Guild.Manager.Application.Common.Responses;

public class Response<T0> : OneOfBase<T0, IErrorResponse> where T0 : ISuccessReponse
{
    protected Response(OneOf<T0, IErrorResponse> input) : base(input)
    {
    }

    public static Response<T0> FromT1(IErrorResponse errorResponse) => new(OneOf<T0, IErrorResponse>.FromT1(errorResponse));

    public static implicit operator Response<T0>(T0 _) => new(_);
    public static implicit operator Response<T0>(ValidationErrorResponse _) => new(_);
}
