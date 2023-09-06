using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class ScoringProfileFunctionDistance
{
    [JsonPropertyName("referencePointParameter")]
    public string ReferencePointParameter { get; set; }

    [JsonPropertyName("boostingDistance")]
    public double BoostingDistance { get; set; }
}

public class ScoringProfileFunctionTag
{
    [JsonPropertyName("tagsParameter")]
    public string TagsParameter { get; set; }
}