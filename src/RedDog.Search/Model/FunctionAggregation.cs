using System.Text.Json.Serialization;

using RedDog.Search.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<FunctionAggregation>))]
public enum FunctionAggregation
{
    Sum,
    Average,
    Minimum,
    Maximum,
    FirstMatching
}