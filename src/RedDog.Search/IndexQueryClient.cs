using System.Globalization;
using System.Linq;
using System.Net.Http;

using RedDog.Search.Http;
using RedDog.Search.Model;

namespace RedDog.Search;

public class IndexQueryClient(ApiConnection connection) : IDisposable
{
    private ApiConnection _connection = connection;

    /// <summary>
    /// Search an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    public Task<IApiResponse<SearchQueryResult>> SearchAsync(
        string indexName,
        SearchQuery query,
        CancellationToken cancellationToken = default)
    {
        var request = new ApiRequest($"indexes/{indexName}/docs", HttpMethod.Get);
        if (!string.IsNullOrEmpty(query.Query))
            request.AddQueryParameter("search", query.Query);
        if (query.Mode.HasValue)
            request.AddQueryParameter("searchMode", query.Mode.ToString()!.ToLowerInvariant());
        if (!string.IsNullOrEmpty(query.SearchFields))
            request.AddQueryParameter("searchFields", query.SearchFields);
        if (query.Skip > 0)
            request.AddQueryParameter("$skip", query.Skip.ToString(CultureInfo.InvariantCulture));
        if (query.Top > 0)
            request.AddQueryParameter("$top", query.Top.ToString(CultureInfo.InvariantCulture));
        if (query.Count)
            request.AddQueryParameter("$count", query.Count.ToString().ToLower());
        if (!string.IsNullOrEmpty(query.OrderBy))
            request.AddQueryParameter("$orderby", query.OrderBy);
        if (!string.IsNullOrEmpty(query.Select))
            request.AddQueryParameter("$select", query.Select);
        if (query.Facets != null && query.Facets.Any())
            request.AddQueryParameter("facet", query.Facets);
        if (!string.IsNullOrEmpty(query.Filter))
            request.AddQueryParameter("$filter", query.Filter);
        if (!string.IsNullOrEmpty(query.Highlight))
            request.AddQueryParameter("highlight", query.Highlight);

        // Both HighlightPreTag AND HighlightPostTag need to be set together
        if (!string.IsNullOrEmpty(query.HighlightPreTag) && !String.IsNullOrEmpty(query.HighlightPostTag))
        {
            request.AddQueryParameter("highlightPreTag", query.HighlightPreTag);
            request.AddQueryParameter("highlightPostTag", query.HighlightPostTag);
        }
        if (!string.IsNullOrEmpty(query.ScoringProfile))
            request.AddQueryParameter("scoringProfile", query.ScoringProfile);
        if (query.ScoringParameters != null && query.ScoringParameters.Any())
            request.AddQueryParameter("scoringParameter", query.ScoringParameters);

        return _connection.Execute<SearchQueryResult>(request, cancellationToken);
    }


    public Task<IApiResponse<SearchQueryResult>> SearchAsync(string nextLink, CancellationToken cancellationToken = default)
    {
        return _connection.Execute<SearchQueryResult>(new RawApiRequest(nextLink, HttpMethod.Get), cancellationToken);
    }

    /// <summary>
    /// Get suggestions from an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken">cancel token</param>
    /// <returns></returns>
    public Task<IApiResponse<SuggestionResult>> SuggestAsync(string indexName, SuggestionQuery query, CancellationToken cancellationToken = default)
    {
        var request = new ApiRequest($"indexes/{indexName}/docs/suggest", HttpMethod.Get);
        if (!String.IsNullOrEmpty(query.Search))
            request.AddQueryParameter("search", query.Search);

        request.AddQueryParameter("fuzzy", query.Fuzzy ? Boolean.TrueString : Boolean.FalseString);

        if (!String.IsNullOrEmpty(query.SearchFields))
            request.AddQueryParameter("searchFields", query.SearchFields);

        if (query.Top > 0)
            request.AddQueryParameter("$top", query.Top.ToString(CultureInfo.InvariantCulture));

        if (!String.IsNullOrEmpty(query.OrderBy))
            request.AddQueryParameter("$orderby", query.OrderBy);
        if (!String.IsNullOrEmpty(query.Select))
            request.AddQueryParameter("$select", query.Select);

        if (!String.IsNullOrEmpty(query.SuggesterName))
            request.AddQueryParameter("suggesterName", query.SuggesterName);

        if (!String.IsNullOrEmpty(query.Filter))
            request.AddQueryParameter("$filter", query.Filter);

        return _connection.Execute<SuggestionResult>(request, cancellationToken);
    }

    /// <summary>
    /// Lookup a document from an index.
    /// </summary>
    /// <param name="indexName"></param>
    /// <param name="query"></param>
    /// <param name="cancellationToken">cancel token</param>
    /// <returns></returns>
    public Task<IApiResponse<LookupQueryResult>> LookupAsync(string indexName, LookupQuery query, CancellationToken cancellationToken = default)
    {
        var request = new ApiRequest($"indexes/{indexName}/docs/{query.Key}", HttpMethod.Get);

        if (!String.IsNullOrEmpty(query.Select))
            request.AddQueryParameter("$select", query.Select);

        return _connection.Execute<LookupQueryResult>(request, cancellationToken);
    }

    ~IndexQueryClient()
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
                _connection = null;
            }
        }
    }
}