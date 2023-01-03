using Microsoft.Extensions.Options;
using RestSharp;
using TwitterClient.Client.Configuration;
using TwitterClient.Client.ResponseBuilder;
using TwitterClient.Client.Tweets.PostModels;
using TwitterClient.Client.Tweets.ResponseModels;
using TwitterClient.Models;

namespace TwitterClient.Client.Tweets;

internal class TweetsClient : BaseTwitterClient, ITweetsClient
{
    public TweetsClient(
        IOptions<TwitterClientConfiguration> configuration, 
        ITwitterClientResponseBuilder responseBuilder) :base(configuration, responseBuilder)
    {
        
    }

    public async Task<TwitterClientResponse> Like(string userId, string tweetId)
    {
        var likeResource = string.Format(Resources.Resources.LikeTweet, userId);
        var req = new RestRequest(likeResource) { RequestFormat = DataFormat.Json };
        req.AddJsonBody(new LikeAndRetweetBody { TweetId = tweetId });

        var apiResponse = await Client.ExecuteAsync<TwitterApiResponse<LikedTweetResponse>>(req, Method.Post);
        return ResponseBuilder.BuildResponse(apiResponse);
    }

    public async Task<TwitterClientResponse> Retweet(string userId, string tweetId)
    {
        var retweetResource = string.Format(Resources.Resources.RetweetTweet, userId);
        var req = new RestRequest(retweetResource) { RequestFormat = DataFormat.Json };
        req.AddJsonBody(new LikeAndRetweetBody { TweetId = tweetId });
        
        var apiResponse = await Client.ExecuteAsync<TwitterApiResponse<RetweetedTweetResponse>>(req, Method.Post);
        return ResponseBuilder.BuildResponse(apiResponse);
    }

    public async Task<TwitterClientResponse> Create(string tweetText)
    {
        var req = new RestRequest(Resources.Resources.CreateTweet);
        req.AddJsonBody(new CreateTweetBody { Text = tweetText });

        var apiResponse = await Client.ExecuteAsync<TwitterApiResponse<CreatedTweetResponse>>(req, Method.Post);
        return ResponseBuilder.BuildResponse(apiResponse);
    }

    public async Task<TwitterClientResponse> Delete(string tweetId)
    {
        var deleteResource = string.Format(Resources.Resources.DeleteTweet, tweetId);
        var req = new RestRequest(deleteResource);

        var apiResponse = await Client.ExecuteAsync<TwitterApiResponse<DeletedTweetResponse>>(req, Method.Delete);
        return ResponseBuilder.BuildResponse(apiResponse);
    }
}