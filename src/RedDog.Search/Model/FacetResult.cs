using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class FacetResult
{
    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("from")]
    public long From { get; set; }

    [JsonPropertyName("to")]
    public long To { get; set; }

    [JsonPropertyName("count")]
    public long Count { get; set; }
}