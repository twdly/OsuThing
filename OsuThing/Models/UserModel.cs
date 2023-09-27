using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class UserModel
{
    [JsonPropertyName("username")] public string? Username { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("avatar_url")] public string? Avatar { get; set; }
}