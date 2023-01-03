using System.Text.Json.Serialization;

namespace TwitterClient.Client.Tweets.PostModels;

internal class LikeAndRetweetBody
{
    [JsonPropertyName("tweet_id")]
    public string TweetId { get; set; }
}