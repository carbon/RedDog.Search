using System.Text.Json.Serialization;

using RedDog.Search.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<SuggesterSearchMode>))]
public enum SuggesterSearchMode
{
    AnalyzingInfixMatching
}
