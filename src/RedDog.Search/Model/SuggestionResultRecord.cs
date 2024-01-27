using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SuggestionResultRecord
{
    public SuggestionResultRecord()
    {
        Properties = [];
    }
    
    [JsonPropertyName("@search.text")]
    public string Text { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> Properties { get; set; }
}