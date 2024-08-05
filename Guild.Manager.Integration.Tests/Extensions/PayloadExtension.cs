using System.Net.Mime;
using System.Text;

namespace Guild.Manager.Integration.Tests.Extensions;

internal static class PayloadExtension
{
    public static HttpContent ToHtttpContent(this string payload)
    {
        return new StringContent(payload, Encoding.UTF8, MediaTypeNames.Application.Json);
    }
}
