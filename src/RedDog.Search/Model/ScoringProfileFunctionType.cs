using RedDog.Search.Serialization;
using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<ScoringProfileFunctionType>))]
public enum ScoringProfileFunctionType
{
    Magnitude,
    Freshness,
    Distance,
    Tag
}