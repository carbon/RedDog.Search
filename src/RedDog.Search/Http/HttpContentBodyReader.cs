using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace RedDog.Search.Http;

/// <summary>
///     Wrapper that allows passing around the ReadAsAsync method.
/// </summary>
internal class HttpContentBodyReader(HttpContent content, JsonSerializerOptions formatter) : IBodyReader
{
    private readonly HttpContent _content = content;
    private readonly JsonSerializerOptions _formatter = formatter;

    public Task<T> ReadAsync<T>(CancellationToken cancellationToken = default)
    {
        return _content.ReadFromJsonAsync<T>(_formatter, cancellationToken);
    }
}