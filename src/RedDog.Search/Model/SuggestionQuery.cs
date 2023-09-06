using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SuggestionQuery
{
    public SuggestionQuery()
    {

    }

    public SuggestionQuery(string search)
    {
        Search = search;
    }

    [JsonPropertyName("search")]
    public string Search { get; set; }

    [JsonPropertyName("fuzzy")]
    public bool Fuzzy { get; set; }

    [JsonPropertyName("searchFields")]
    public string SearchFields { get; set; }

    [JsonPropertyName("top")]
    public long Top { get; set; }

    [JsonPropertyName("filter")]
    public string Filter { get; set; }

    [JsonPropertyName("orderBy")]
    public string OrderBy { get; set; }

    [JsonPropertyName("select")]
    public string Select { get; set; }

    [JsonPropertyName("suggesterName")]
    public string SuggesterName { get; set; }
}