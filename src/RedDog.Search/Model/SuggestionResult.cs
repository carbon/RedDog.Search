using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SuggestionResult
{  
    [JsonPropertyName("value")]
    public IEnumerable<SuggestionResultRecord> Records
    {
        get;
        set;
    }

    [JsonPropertyName("@odata.context")]
    public string Context
    {
        get;
        set;
    }        
}