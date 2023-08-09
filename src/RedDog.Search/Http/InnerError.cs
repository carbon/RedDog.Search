using System.Text.Json.Serialization;

namespace RedDog.Search.Http;

public class InnerError
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("stacktrace")]
    public string Stacktrace { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}