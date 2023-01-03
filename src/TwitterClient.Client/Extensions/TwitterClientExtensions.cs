using Microsoft.Extensions.DependencyInjection;
using TwitterClient.Client.Configuration;
using TwitterClient.Client.ResponseBuilder;
using TwitterClient.Client.Tweets;

namespace TwitterClient.Client.Extensions;

public static class TwitterClientExtensions
{
    public static void AddTwitterClient(this IServiceCollection services, Action<TwitterClientConfiguration> config)
    {
        // Configure client credentials
        services.Configure(config);
        
        // Response builder
        AddResponseBuilder(services);
        
        // Configure sub clients
        services.AddTransient<ITweetsClient, TweetsClient>();
    }

    private static void AddResponseBuilder(IServiceCollection services) => 
        services.AddTransient<ITwitterClientResponseBuilder, TwitterClientResponseBuilder>();
}