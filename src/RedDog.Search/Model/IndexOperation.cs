using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class IndexOperation
{
    public IndexOperation(IndexOperationType action, string keyField, string keyValue)
    {
        Action = action;
        Properties = new Dictionary<string, object> {{keyField, keyValue}};
    }

    [JsonPropertyName("@search.action")]
    public IndexOperationType Action { get; set; }

    [JsonExtensionData]
    public Dictionary<string, object> Properties { get; set; }
}