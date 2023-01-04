namespace TwitterClient.UnitTests.ResponseBuilder;

public record TestResponse
{
    public bool ActionSucceeded { get; set; }
    
    public override string ToString()
    {
        return ActionSucceeded.ToString();
    }
}