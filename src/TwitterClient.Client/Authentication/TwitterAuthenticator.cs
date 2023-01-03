using RestSharp;
using RestSharp.Authenticators;

namespace TwitterClient.Client.Authentication;

internal class TwitterAuthenticator : AuthenticatorBase
{
    private readonly string _baseUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;

    public TwitterAuthenticator(string baseUrl, string clientId, string clientSecret) : base("") {
        _baseUrl = baseUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
    }

    protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken) {
        Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
        return new HeaderParameter(KnownHeaders.Authorization, Token);
    }

    private async Task<string> GetToken()
    {
        var options = new RestClientOptions(_baseUrl);
        using var client = new RestClient(options) {
            Authenticator = new HttpBasicAuthenticator(_clientId, _clientSecret),
        };

        var request = new RestRequest(Resources.Resources.GetAuthToken)
            .AddParameter("grant_type", "client_credentials");
        var response = await client.PostAsync<TokenResponse>(request);
        return $"{response!.TokenType} {response!.AccessToken}";
    }
}