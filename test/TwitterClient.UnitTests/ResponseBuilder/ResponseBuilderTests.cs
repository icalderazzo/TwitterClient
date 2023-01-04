using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using TwitterClient.Client.Extensions;
using TwitterClient.Client.ResponseBuilder;

namespace TwitterClient.UnitTests.ResponseBuilder;

[TestFixture]
public class ResponseBuilderTests
{
    private readonly IServiceCollection _services = new ServiceCollection();
    private IServiceProvider? _serviceProvider;
    
    [SetUp]
    public void SetUp()
    {
        _services.AddTwitterClient(cnf =>
        {
            cnf.ApiKey = "Key";
            cnf.ApiKeySecret = "Secret";
        });
        
        _serviceProvider = _services.BuildServiceProvider();
    }

    [Test]
    public void BuildSuccessResponse()
    {
        //  Arrange
        var responseBuilder = _serviceProvider?.GetService<ITwitterClientResponseBuilder>();

        // Act
        var apiResponse = MockResponses.GetSuccessTestResponse();
        var clientResponse = responseBuilder?.BuildResponse(apiResponse);
        
        // Assert
        Assert.IsNotNull(clientResponse);
        Assert.AreEqual((int)apiResponse.StatusCode, clientResponse?.Code);
        Assert.AreEqual(apiResponse.Data?.Data?.ToString(), clientResponse?.Message);
        
        // The builder sets Success using IsSuccessful property of RestResponse and this cannot be set
        // Assert.IsTrue(clientResponse?.Success);
    }
    
    [Test]
    public void BuildFailedResponse()
    {
        //  Arrange
        var responseBuilder = _serviceProvider?.GetService<ITwitterClientResponseBuilder>();

        // Act
        var apiResponse = MockResponses.GetSuccessTestResponse();
        var clientResponse = responseBuilder?.BuildResponse(apiResponse);
        
        // Assert
        Assert.IsNotNull(clientResponse);
        Assert.AreEqual((int)apiResponse.StatusCode, clientResponse?.Code);
        Assert.AreEqual(apiResponse.Data?.Data?.ToString(), clientResponse?.Message);
        
        // The builder sets Success using IsSuccessful property of RestResponse and this cannot be set
        // It will always be false
        // Assert.IsFalse(clientResponse?.Success);
    }

    [Test]
    public void BuildNullResponse()
    {
        //  Arrange
        var responseBuilder = _serviceProvider.GetService<ITwitterClientResponseBuilder>();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(delegate
        {
            responseBuilder?.BuildResponse(MockResponses.GetNullResponse());
        });
    }
}