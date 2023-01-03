using System.Text.Json.Serialization;

namespace TwitterClient.Models.User;

public class UserPublicMetrics : TwitterClientModel
{
    [JsonPropertyName("followers_count")]
    public int FollowersCount { get; set; }
    
    [JsonPropertyName("following_count")]
    public int FollowingCount { get; set; }
    
    [JsonPropertyName("tweet_count")]
    public int TweetCount { get; set; }
    
    [JsonPropertyName("listed_count")]
    public int ListedCount { get; set; }
}