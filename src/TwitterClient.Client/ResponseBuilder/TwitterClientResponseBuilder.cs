using RestSharp;
using TwitterClient.Models;

namespace TwitterClient.Client.ResponseBuilder;

internal class TwitterClientResponseBuilder : ITwitterClientResponseBuilder
{
    public TwitterClientResponse BuildResponse<T>(RestResponse<TwitterApiResponse<T>> response)
    {
        if (response is null) throw new ArgumentException("Unexpected null API response");

        return new TwitterClientResponse {
            Success = response.IsSuccessful,
            Code = (int) response.StatusCode,
            Message = response.Data?.Data?.ToString()
        };
    }

    public TwitterClientDataResponse<T> BuildDataResponse<T>(RestResponse<TwitterApiResponse<T>> response)
    {
        if (response is null) throw new ArgumentException("Unexpected null API response");

        var clientResponse = new TwitterClientDataResponse<T>
        {
            Success = response.IsSuccessful,
            Code = (int)response.StatusCode,
            Message = response.IsSuccessful ? "Success" : $"Error: {response.ErrorMessage}"
        };

        if (response.Data is not null) clientResponse.Data = response.Data.Data;

        return clientResponse;
    }
}