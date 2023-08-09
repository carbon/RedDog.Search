using System.Text.Json.Serialization;

namespace RedDog.Search.Http;

public class Error
{
    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("innererror")]
    public InnerError InnerError { get; set; }

    public Dictionary<string, List<string>> ModelState { get; set; }
}