using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SearchQueryResult
{
    [JsonPropertyName("@odata.count")]
    public int Count
    {
        get;
        set;
    }

    [JsonPropertyName("@search.facets")]
    public Dictionary<string, FacetResult[]> Facets
    {
        get;
        set;
    }

    [JsonPropertyName("value")]
    public IEnumerable<SearchQueryRecord> Records
    {
        get;
        set;
    }

    [JsonPropertyName("@odata.nextLink")]
    public string NextLink
    {
        get;
        set;
    }
}