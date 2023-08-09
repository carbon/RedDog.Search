using System.Text.Json.Serialization;
using RedDog.Search.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfileFunctionFreshness
{
    [JsonPropertyName("boostingDuration")]
    [JsonConverter(typeof(XsdDurationConverter))]
    public TimeSpan BoostingDuration { get; set; }
}