namespace TwitterClient.Models;

public class TwitterClientDataResponse<T> : TwitterClientResponse
{
    public T? Data { get; set; }
}