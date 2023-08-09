using System.Net.Http;

namespace RedDog.Search.Http;

public class ApiRequest(string uri, HttpMethod method, object? body = null) : IApiRequest
{
    public string Uri { get; } = uri;

    public HttpMethod Method { get; } = method;

    public List<Tuple<string, string>> QueryParameters { get; set; } = new List<Tuple<string, string>>();

    public object? Body { get; set; } = body;

    public void AddQueryParameter(string key, string value)
    {
        QueryParameters.Add(new Tuple<string, string>(key, value));
    }

    public void AddQueryParameter(string key, IEnumerable<string> values)
    {
        foreach (var value in values)
        {
            QueryParameters.Add(new Tuple<string, string>(key, value)); 
        }           
    }
}