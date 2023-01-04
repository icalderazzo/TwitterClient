using RestSharp;
using TwitterClient.Models;

namespace TwitterClient.Client.ResponseBuilder;

public interface ITwitterClientResponseBuilder
{
    TwitterClientResponse BuildResponse<T>(RestResponse<TwitterApiResponse<T>> response);
    TwitterClientDataResponse<T> BuildDataResponse<T>(RestResponse<TwitterApiResponse<T>> response);
}