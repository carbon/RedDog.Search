using RedDog.Search.Serialization;
using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<SearchMode>))]
public enum SearchMode
{
    Any,
    All
}