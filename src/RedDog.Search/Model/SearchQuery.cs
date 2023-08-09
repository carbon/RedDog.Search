using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SearchQuery
{
    public SearchQuery()
    {
    }

    public SearchQuery(string query)
    {
        Query = query;
    }

    [JsonPropertyName("query")]
    public string Query { get; set; }

    [JsonPropertyName("mode")]
    public SearchMode? Mode { get; set; }

    [JsonPropertyName("searchFields")]
    public string SearchFields { get; set; }

    [JsonPropertyName("skip")]
    public long Skip { get; set; }

    [JsonPropertyName("top")]
    public long Top { get; set; }

    [JsonPropertyName("count")]
    public bool Count { get; set; }

    [JsonPropertyName("orderBy")]
    public string? OrderBy { get; set; }

    [JsonPropertyName("select")]
    public string? Select { get; set; }

    [JsonPropertyName("facet")]
    public IEnumerable<string> Facets { get; set; }

    [JsonPropertyName("filter")]
    public string Filter { get; set; }

    [JsonPropertyName("highlight")]
    public string? Highlight { get; set; }

    [JsonPropertyName("highlightPreTag")]
    public string? HighlightPreTag { get; set; }

    [JsonPropertyName("highlightPostTag")]
    public string? HighlightPostTag { get; set; }

    [JsonPropertyName("scoringProfile")]
    public string? ScoringProfile { get; set; }

    [JsonPropertyName("scoringParameter")]
    public IEnumerable<string> ScoringParameters { get; set; }
}