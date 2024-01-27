using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class Suggester
{
    public Suggester()
    {
        SourceFields = [];
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("searchMode")]
    public SuggesterSearchMode SearchMode { get; set; }

    [JsonPropertyName("sourceFields")]
    public List<string> SourceFields { get; set; }
}
