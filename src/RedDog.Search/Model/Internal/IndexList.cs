using System.Text.Json.Serialization;

using RedDog.Search.Http;

namespace RedDog.Search.Model.Internal;

internal class IndexList
{
    [JsonPropertyName("value")]
    public IEnumerable<SearchIndex> Items { get; set; }

    public static async Task<IEnumerable<SearchIndex>> GetIndexes(IBodyReader reader, CancellationToken cancellationToken = default)
    {
        var body = await reader.ReadAsync<IndexList>(cancellationToken)
            .ConfigureAwait(false);
        return body.Items;
    }
}