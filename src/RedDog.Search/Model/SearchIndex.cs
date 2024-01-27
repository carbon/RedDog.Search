#nullable disable

using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class SearchIndex
{
    public SearchIndex()
    {
        Fields = [];
        ScoringProfiles = [];
        Suggesters = [];
    }

    public SearchIndex(string name)
        : this()
    {
        Name = name;
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("fields")]
    public List<IndexField> Fields { get; set; }

#nullable enable

    [JsonPropertyName("scoringProfiles")]
    public List<ScoringProfile>? ScoringProfiles { get; set; }

    [JsonPropertyName("suggesters")]
    public List<Suggester>? Suggesters { get; set; }

    [JsonPropertyName("defaultScoringProfile")]
    public string? DefaultScoringProfile { get; set; }

    [JsonPropertyName("corsOptions")]
    public CorsOptions? CorsOptions { get; set; }
}