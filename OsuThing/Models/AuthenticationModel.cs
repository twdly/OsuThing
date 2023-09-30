using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class AuthenticationModel
{
    [JsonPropertyName("access_token")] public required string AccessToken { get; set; }
    [JsonPropertyName("expires_in")] public required int ExpiresIn { get; set; }
    [JsonPropertyName("token_type")] public required string TokenType { get; set; }
}