using System.Text.Json.Serialization;
namespace RedDog.Search.Model;

public class IndexField
{
    public IndexField(string name, string type)
    {
        Name = name;
        Type = type;
    }

    public IndexField()
    {
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("searchable")]
    public bool Searchable { get; set; }

    [JsonPropertyName("filterable")]
    public bool Filterable { get; set; }

    [JsonPropertyName("sortable")]
    public bool Sortable { get; set; }

    [JsonPropertyName("facetable")]
    public bool Facetable { get; set; }

    [ObsoleteAttribute("Consider using the suggesters property introduced in version 2014-10-20-Preview instead of this option for suggestions. In a future version the suggestions property will be deprecated in favor of using a separate suggesters specification.")]
    [JsonPropertyName("suggestions")]
    public bool Suggestions { get; set; }

    [JsonPropertyName("key")]
    public bool Key { get; set; }

    [JsonPropertyName("retrievable")]
    public bool Retrievable { get; set; }

    [JsonPropertyName("analyzer")]
    public string Analyzer { get; set; }
}