using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace RedDog.Search.Serialization;

public class XsdDurationConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return XmlConvert.ToTimeSpan(reader.GetString()!);
    }

    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        var r = XmlConvert.ToString(value);

        writer.WriteStringValue(r);
    }
}
