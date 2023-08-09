using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfile
{
    public ScoringProfile()
    {
        Functions = new List<ScoringProfileFunction>();
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("text")]
    public ScoringProfileText Text { get; set; }

    [JsonPropertyName("functions")]
    public List<ScoringProfileFunction> Functions { get; set; }

    [JsonPropertyName("functionAggregation")]
    public FunctionAggregation? FunctionAggregation { get; set; }
}