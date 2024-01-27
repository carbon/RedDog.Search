using System.Net.Http;

namespace RedDog.Search.Http;

public class ApiRequest(
    string uri,
    HttpMethod method,
    object? body = null) : IApiRequest
{
    public string Uri { get; } = uri;

    public HttpMethod Method { get; } = method;

    public List<(string, string)> QueryParameters { get; set; } = [];

    public object? Body { get; set; } = body;

    public void AddQueryParameter(string key, string value)
    {
        QueryParameters.Add(new(key, value));
    }

    public void AddQueryParameter(string key, IEnumerable<string> values)
    {
        foreach (var value in values)
        {
            QueryParameters.Add(new(key, value)); 
        }           
    }
}