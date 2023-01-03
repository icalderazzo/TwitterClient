namespace TwitterClient.Client.Tweets.ResponseModels;

internal record CreatedTweetResponse
{
    public string Id { get; set; }
    public string Text { get; set; }
}