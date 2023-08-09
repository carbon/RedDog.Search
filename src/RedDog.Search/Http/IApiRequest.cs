using System.Net.Http;

namespace RedDog.Search.Http;

public interface IApiRequest
{
    string Uri { get; }

    object? Body { get; set; }

    HttpMethod Method { get; }

    List<Tuple<string, string>> QueryParameters { get; set; }

    void AddQueryParameter(string key, string value);
}