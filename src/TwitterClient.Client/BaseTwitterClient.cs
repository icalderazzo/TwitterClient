using Microsoft.Extensions.Options;
using RestSharp;
using TwitterClient.Client.Authentication;
using TwitterClient.Client.Configuration;
using TwitterClient.Client.ResponseBuilder;

namespace TwitterClient.Client;

internal abstract class BaseTwitterClient : IBaseTwitterClient, IDisposable
{
    protected readonly RestClient Client;
    protected readonly ITwitterClientResponseBuilder ResponseBuilder;

    protected BaseTwitterClient(
        IOptions<TwitterClientConfiguration> clientConfiguration, 
        ITwitterClientResponseBuilder responseBuilder)
    {
        var configuration = clientConfiguration.Value;
        var options = new RestClientOptions(Urls.ApiV2Url);

        Client = new RestClient(options)
        {
            Authenticator = new TwitterAuthenticator(
                Urls.ApiV2Url, 
                configuration.ApiKey, 
                configuration.ApiKeySecret)
        };

        ResponseBuilder = responseBuilder;
    }
    
    public void Dispose()
    {
        Client.Dispose();
        GC.SuppressFinalize(this);
    }
} 