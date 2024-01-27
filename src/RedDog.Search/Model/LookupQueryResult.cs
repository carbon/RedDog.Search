using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class LookupQueryResult
{
    [JsonExtensionData]
    public Dictionary<string, object> Properties { get; set; } = [];
}