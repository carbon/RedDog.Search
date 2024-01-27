using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfileFunctionMagnitude
{
    [JsonPropertyName("boostingRangeStart")]
    public double BoostingRangeStart { get; set; }

    [JsonPropertyName("boostingRangeEnd")]
    public double BoostingRangeEnd { get; set; }

    [JsonPropertyName("constantBoostBeyondRange")]
    public bool ConstantBoostBeyondRange { get; set; }
}