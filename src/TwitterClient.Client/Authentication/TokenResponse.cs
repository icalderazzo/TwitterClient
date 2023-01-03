using System.Text.Json.Serialization;

namespace TwitterClient.Client.Authentication;

internal record TokenResponse
{
    [JsonPropertyName("token_type")]
    public string TokenType { get; set; }
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}