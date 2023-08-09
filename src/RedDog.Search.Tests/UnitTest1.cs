using System.Text.Json;

using RedDog.Search.Model;

namespace RedDog.Search.Tests;

public class UnitTest1
{
    [Fact]
    public void EnumsAreCamelCased()
    {
        Assert.Equal("\"logarithmic\"", JsonSerializer.Serialize(InterpolationType.Logarithmic));

        Assert.Equal(InterpolationType.Logarithmic, JsonSerializer.Deserialize<InterpolationType>("\"logarithmic\""));
    }
}