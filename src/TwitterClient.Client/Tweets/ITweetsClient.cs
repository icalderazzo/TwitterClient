using TwitterClient.Models;

namespace TwitterClient.Client.Tweets;

public interface ITweetsClient
{
    /// <summary>
    ///     Likes a Tweet.
    /// </summary>
    /// <param name="userId">The ID of the user who wishes to like a Tweet. The ID must belong to the authenticating user.</param>
    /// <param name="tweetId">The Tweet ID to give Like to.</param>
    /// <returns></returns>
    Task<TwitterClientResponse> Like(string userId, string tweetId);
    
    /// <summary>
    ///     Retweets a Tweet.
    /// </summary>
    /// <param name="userId">The ID of the user who wishes to retweet a Tweet. The ID must belong to the authenticating user.</param>
    /// <param name="tweetId">The Tweet ID to retweet.</param>
    /// <returns></returns>
    Task<TwitterClientResponse> Retweet(string userId, string tweetId);
    
    /// <summary>
    ///     Creates a Tweet.
    /// </summary>
    /// <param name="tweetText">The Tweet text.</param>
    /// <returns></returns>
    Task<TwitterClientResponse> Create(string tweetText);
    
    /// <summary>
    ///     Deletes a Tweet.
    /// </summary>
    /// <param name="tweetId">The Tweet ID to delete.</param>
    /// <returns></returns>
    Task<TwitterClientResponse> Delete(string tweetId);
}