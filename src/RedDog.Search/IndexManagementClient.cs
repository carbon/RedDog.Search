using System.Net.Http;

using RedDog.Search.Http;
using RedDog.Search.Model;
using RedDog.Search.Model.Internal;

namespace RedDog.Search;

public class IndexManagementClient : IDisposable
{
    private ApiConnection _connection;

    public IndexManagementClient(ApiConnection connection)
    {
        _connection = connection;
    }

    /// <summary>
    /// Create a new index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse<SearchIndex>> CreateIndexAsync(SearchIndex index, CancellationToken cancellationToken = default)
    {
        return _connection.Execute<SearchIndex>(
            new ApiRequest("indexes", HttpMethod.Post) { Body = index }, cancellationToken);
    }

    /// <summary>
    /// Update an existing index.
    /// </summary>
    /// <param name="index"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse<SearchIndex>> UpdateIndexAsync(SearchIndex index, CancellationToken cancellationToken = default)
    {
        return _connection.Execute<SearchIndex>(new ApiRequest($"indexes/{index.Name}", HttpMethod.Put) { Body = index }, cancellationToken);
    }

    /// <summary>
    /// Delete an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse> DeleteIndexAsync(string indexName, CancellationToken cancellationToken = default)
    {
        return _connection.Execute(new ApiRequest($"indexes/{indexName}", HttpMethod.Delete), cancellationToken);
    }

    /// <summary>
    /// Get an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse<SearchIndex>> GetIndexAsync(string indexName, CancellationToken cancellationToken = default)
    {
        return _connection.Execute<SearchIndex>(new ApiRequest($"indexes/{indexName}", HttpMethod.Get), cancellationToken);
    }

    /// <summary>
    /// Get the index statistics.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse<IndexStatistics>> GetIndexStatisticsAsync(string indexName, CancellationToken cancellationToken = default)
    {
        return _connection.Execute<IndexStatistics>(new ApiRequest($"indexes/{indexName}/stats", HttpMethod.Get), cancellationToken);
    }

    /// <summary>
    /// Get all indexes.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IApiResponse<IEnumerable<SearchIndex>>> GetIndexesAsync(CancellationToken cancellationToken = default)
    {
        var request = new ApiRequest("indexes", HttpMethod.Get);
        return _connection.Execute(request, cancellationToken, IndexList.GetIndexes);
    }


    /// <summary>
    /// Populate an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="operations"></param>
    /// <returns></returns>
    public Task<IApiResponse<IEnumerable<IndexOperationResult>>> PopulateAsync(string indexName, params IndexOperation[] operations)
    {
        return PopulateAsync(indexName, default, operations);
    }

    /// <summary>
    /// Populate an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="operations"></param>
    /// <returns></returns>
    public Task<IApiResponse<IEnumerable<IndexOperationResult>>> PopulateAsync(string indexName, CancellationToken cancellationToken, params IndexOperation[] operations)
    {
        return _connection.Execute(new ApiRequest($"indexes/{indexName}/docs/index", HttpMethod.Post)
            .WithBody(new { value = operations }), cancellationToken, IndexOperationList.GetIndexes);
    }

    ~IndexManagementClient()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Dispose resources.
    /// </summary>
    /// <param name="disposing"></param>
    public virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null!;
            }
        }
    }
}