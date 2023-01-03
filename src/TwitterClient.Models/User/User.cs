using System.Text.Json.Serialization;

namespace TwitterClient.Models.User;

public class User : TwitterClientModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    
    public string Description { get; set; }
    
    [JsonPropertyName("profile_image_url")]
    public string ProfileImageUrl { get; set; }
    
    public UserPublicMetrics UserPublicMetrics { get; set; }
}