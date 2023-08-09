using System.Text.Json.Serialization;

using RedDog.Search.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<InterpolationType>))]
public enum InterpolationType
{
    Linear = 0,
    Constant = 1,
    Quadratic = 2,
    Logarithmic = 3
}