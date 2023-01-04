namespace TwitterClient.Client;

public record TwitterApiResponse<T>
{
    public T? Data { get; set; }
}