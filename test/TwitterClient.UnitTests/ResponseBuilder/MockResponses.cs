using System.Net;
using RestSharp;
using TwitterClient.Client;

namespace TwitterClient.UnitTests.ResponseBuilder;

public static class MockResponses
{
    public static RestResponse<TwitterApiResponse<TestResponse>> GetSuccessTestResponse()
    {
        return new RestResponse<TwitterApiResponse<TestResponse>>()
        {
            StatusCode = HttpStatusCode.Created,
            IsSuccessStatusCode = true,
            Data = new TwitterApiResponse<TestResponse>
            {
                Data = new TestResponse { ActionSucceeded = true }
            }
        };
    }
    
    public static RestResponse<TwitterApiResponse<TestResponse>> GetFailedTestResponse()
    {
        return new RestResponse<TwitterApiResponse<TestResponse>>()
        {
            StatusCode = HttpStatusCode.BadRequest,
            IsSuccessStatusCode = false,
            Data = new TwitterApiResponse<TestResponse>
            {
                Data = new TestResponse { ActionSucceeded = false }
            }
        };
    }

    public static RestResponse<TwitterApiResponse<TestResponse>>? GetNullResponse() { return null; }
}