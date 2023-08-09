namespace RedDog.Search.Http
{
    public delegate Task<TResponse> ResultFormatter<TResponse>(IBodyReader reader, CancellationToken cancellationToken);
}