using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public class LookupQuery
{
    public LookupQuery()
    {
    }

    public LookupQuery(string key)
    {
        Key = key;
    }

    [JsonIgnore]
    public String Key { get; set; }

    [JsonPropertyName("select")]
    public string Select { get; set; }
}