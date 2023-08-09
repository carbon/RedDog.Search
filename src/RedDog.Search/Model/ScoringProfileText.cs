using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfileText
{
    public ScoringProfileText()
    {
        Weights = new Dictionary<string, double>();
    }

    [JsonPropertyName("weights")]
    public IDictionary<string, double> Weights { get; set; }
}