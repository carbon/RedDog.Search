using System.Text.Json.Serialization;

using RedDog.Search.Http;

namespace RedDog.Search.Model.Internal;

internal class IndexOperationList
{
    [JsonPropertyName("value")]
    public IEnumerable<IndexOperationResult> Items { get; set; }

    public static async Task<IEnumerable<IndexOperationResult>> GetIndexes(IBodyReader reader, CancellationToken cancellationToken = default)
    {
        var body = await reader.ReadAsync<IndexOperationList>(cancellationToken).ConfigureAwait(false);
        return body.Items;
    }
}