using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SearchQueryRecord
{
    [JsonPropertyName("@search.score")]
    public double Score { get; set; }

    [JsonPropertyName("@search.highlights")]
    public Dictionary<string, string[]> Highlights { get; set; } = [];

    [JsonExtensionData]
    public Dictionary<string, object> Properties { get; set; } = [];
}