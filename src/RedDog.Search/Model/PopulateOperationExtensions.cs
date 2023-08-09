using System.Text.Json.Serialization;

namespace RedDog.Search.Model;

public static class PopulateOperationExtensions
{
    public static IndexOperation WithProperty(this IndexOperation operation, string name, object value)
    {
        operation.Properties.Add(name, value);
        return operation;
    }

    public static IndexOperation WithGeographyPoint(this IndexOperation operation, string name, double longitude, double latitude)
    {
        operation.Properties.Add(name, new GeoPointField(longitude, latitude));
        return operation;
    }

}
internal class GeoPointField
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; }

    public GeoPointField() { }

    public GeoPointField(params double[] coordinates)
    {
        Type = "Point";
        Coordinates = coordinates;
    }
}