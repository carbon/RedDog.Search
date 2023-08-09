using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public sealed class IndexOperationResult
{
    [JsonPropertyName("key")]
    public string Key { get; set; }

    [JsonPropertyName("status")]
    public bool Status { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; set; }
}