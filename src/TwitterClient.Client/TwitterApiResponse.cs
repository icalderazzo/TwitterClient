namespace TwitterClient.Client;

internal record TwitterApiResponse<T>
{
    public T? Data { get; set; }
}