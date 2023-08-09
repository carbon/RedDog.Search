using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfileFunction
{
    [JsonPropertyName("type")]
    public ScoringProfileFunctionType Type { get; set; }

    [JsonPropertyName("boost")]
    public double Boost { get; set; }

    [JsonPropertyName("fieldName")]
    public string FieldName { get; set; }

    [JsonPropertyName("interpolation")]
    public InterpolationType Interpolation { get; set; }

    [JsonPropertyName("magnitude")]
    public ScoringProfileFunctionMagnitude? Magnitude { get; set; }

    [JsonPropertyName("freshness")]
    public ScoringProfileFunctionFreshness? Freshness { get; set; }

    [JsonPropertyName("distance")]
    public ScoringProfileFunctionDistance? Distance { get; set; }

    [JsonPropertyName("tag")]
    public ScoringProfileFunctionTag? Tag { get; set; }
}