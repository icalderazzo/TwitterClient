using System.Text.Json.Serialization;

namespace TwitterClient.Models.Tweet;

public class Tweet : TwitterClientModel
{
    public string Id { get; set; }
    public string Text { get; set; }
    
    [JsonPropertyName("author_id")]
    public string AuthorId { get; set; }
    
    public TweetPublicMetrics PublicMetrics { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    public TweetEntities TweetEntities { get; set; }
}