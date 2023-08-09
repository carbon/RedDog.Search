namespace RedDog.Search.Http;

internal static class ApiRequestExtensions
{
    public static IApiRequest WithBody(this IApiRequest request, object body)
    {
        request.Body = body;
        return request;
    }
}