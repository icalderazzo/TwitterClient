namespace TwitterClient.Models.Tweet;

public class Hashtag : TwitterClientModel
{
    public int Start { get; set; }
    public int End { get; set; }
    public string Tag { get; set; }
}