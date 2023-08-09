using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace RedDog.Search.Serialization;

internal class CamelCaseEnumJsonConverter<T> : JsonConverter<T>
    where T: struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enum.Parse<T>(reader.GetString()!, ignoreCase: true);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var text = value.ToString();

        text = char.ToLowerInvariant(text[0]) + text.Substring(1);

        writer.WriteStringValue(text);

    }
}
