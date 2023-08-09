using System.Net.Http;

namespace RedDog.Search.Http;

public class RawApiRequest(string url, HttpMethod method) : IRawApiRequest
{
    public string Url { get; set; } = url;

    public HttpMethod Method { get; set; } = method;
}
