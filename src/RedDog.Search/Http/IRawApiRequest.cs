using System.Net.Http;

namespace RedDog.Search.Http;

public interface IRawApiRequest
{
    string Url { get; set; }

    HttpMethod Method { get; set; }
}