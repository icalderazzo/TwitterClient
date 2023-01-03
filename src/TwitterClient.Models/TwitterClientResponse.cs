namespace TwitterClient.Models;

/// <summary>
///     The response each sub client method will return.
/// </summary>
public class TwitterClientResponse
{
    public string? Message { get; set; }
    public int Code { get; set; }
    public bool Success { get; set; }
}