namespace RedDog.Search.Http;

public interface IBodyReader
{
    Task<T> ReadAsync<T>(CancellationToken cancellationToken = default);
}