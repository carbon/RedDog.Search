﻿using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

using RedDog.Search.Model.Internal;

namespace RedDog.Search.Http;

public class ApiConnection : IDisposable
{
    private readonly JsonSerializerOptions s_jso = new() {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private HttpClient _client;


    internal ApiConnection(Uri baseUri, string apiKey, SocketsHttpHandler handler)
    {
        BaseUri = baseUri;

        _client = new HttpClient(handler) { BaseAddress = BaseUri };
        _client.DefaultRequestHeaders.Add("api-key", apiKey);
        _client.DefaultRequestHeaders.Add("Accept", "application/json;odata.metadata=none");
    }

    public Uri BaseUri { get; }

    public static ApiConnection Create(Uri baseUri, string apiKey)
    {
        var handler = new SocketsHttpHandler();
        return new ApiConnection(baseUri, apiKey, handler);
    }

    public static ApiConnection Create(string serviceName, string apiKey)
    {
        var handler = new SocketsHttpHandler();
        return new ApiConnection(new Uri(string.Format(ApiConstants.BaseUrl, serviceName)), apiKey, handler);
    }

    /// <summary>
    /// Execute a request that doesn't return a result.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IApiResponse> Execute(IApiRequest request, CancellationToken cancellationToken)
    {
        var response = await Execute(request, cancellationToken, (reader, token) => Task.FromResult(new NullBody()))
            .ConfigureAwait(false);
        return response;
    }

    /// <summary>
    /// Execute a request that doesn't return a result.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<IApiResponse> Execute(IRawApiRequest request, CancellationToken cancellationToken)
    {
        var response = await Execute(request, cancellationToken, (reader, token) => Task.FromResult(new NullBody()))
            .ConfigureAwait(false);
        return response;
    }
    
    /// <summary>
    /// Execute a request which returns a result.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="formatter"></param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    public async Task<IApiResponse<TResponse>> Execute<TResponse>(IApiRequest request, CancellationToken cancellationToken, ResultFormatter<TResponse>? formatter = null)
    {
        // Send the request.
        var responseMessage = await _client.SendAsync(BuildRequest(request), cancellationToken)
            .ConfigureAwait(false);

        // Build the response.
        return await BuildResponse(responseMessage, cancellationToken, formatter)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Execute a request which returns a result.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="request"></param>
    /// <param name="formatter"></param>
    /// <returns></returns>
    public async Task<IApiResponse<TResponse>> Execute<TResponse>(IRawApiRequest uriRequest, CancellationToken cancellationToken, ResultFormatter<TResponse>? formatter = null)
    {
        // Send the request.
        var responseMessage = await _client.SendAsync(new HttpRequestMessage(uriRequest.Method, uriRequest.Url))
            .ConfigureAwait(false);

        // Build the response.
        return await BuildResponse(responseMessage, cancellationToken, formatter)
            .ConfigureAwait(false);
    }

    /// <summary>
    /// Build the HttpRequestMessage based the ApiRequest.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private HttpRequestMessage BuildRequest(IApiRequest request)
    {
        var url = BuildUrl(request);
        var requestMessage = new HttpRequestMessage(request.Method, url);
        requestMessage.Content = request.Body != null ? JsonContent.Create(request.Body, request.Body.GetType(), new MediaTypeHeaderValue("application/json"), s_jso) : requestMessage.Content;
        return requestMessage;
    }


    /// <summary>
    /// Build the ApiResponse based on the HttpResponseMessage.
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="formatter"></param>
    /// <returns></returns>
    private async Task<IApiResponse<TResponse>> BuildResponse<TResponse>(HttpResponseMessage message, CancellationToken cancellationToken, ResultFormatter<TResponse>? formatter = null)
    {
        var response = new ApiResponse<TResponse> { 
            StatusCode = message.StatusCode, 
            IsSuccess = message.IsSuccessStatusCode 
        };

        if (message.Content != null)
        {
            if (message.IsSuccessStatusCode)
            {
                if (formatter != null)
                {
                    // The formatter allows us to handle a body wrapped in a root element.
                    response.Body = await formatter(new HttpContentBodyReader(message.Content, s_jso), cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    // The complete body can be deserialized to an object.
                    response.Body = await message.Content.ReadFromJsonAsync<TResponse>(s_jso, cancellationToken).ConfigureAwait(false);
                }
            }
            else
            {
                // Errors should also be deserialized.
                var errorResponse = await message.Content.ReadFromJsonAsync<ErrorResponse>(JsonSerializerOptions.Default, cancellationToken)
                    .ConfigureAwait(false);
                if (errorResponse != null)
                {
                    response.Error = errorResponse.Error;
                }
            }
        }
        return response;
    }

    /// <summary>
    /// Build the url with parameters and make sure we always add the api version.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    private string BuildUrl(IApiRequest request)
    {
        string url = request.Uri;
        List<string> parameters = request.QueryParameters.Select(
            p => FormatQueryStringParameter(p.Item1, p.Item2)).ToList();

        parameters.Add(FormatQueryStringParameter("api-version", ApiConstants.Version));
        return url + "?" + string.Join("&", parameters);
    }

    /// <summary>
    /// Format a query string parameter.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    private static string FormatQueryStringParameter(string key, string value)
    {
        return $"{Uri.EscapeUriString(key)}={WebUtility.UrlEncode(value)}";
    }

    ~ApiConnection()
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
            if (_client != null)
            {
                _client.Dispose();
                _client = null!;
            }
        }
    }
}