using RedDog.Search.Serialization;
using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

[JsonConverter(typeof(CamelCaseEnumJsonConverter<IndexOperationType>))]
public enum IndexOperationType
{
    Upload,
    Merge,
    MergeOrUpload,
    Delete
}