using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class IndexStatistics
{
    [JsonPropertyName("documentCount")]
    public long DocumentCount { get; set; }

    [JsonPropertyName("storageSize")]
    public long StorageSize { get; set; }
}