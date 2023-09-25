using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class AuthenticationModel
{
    [JsonPropertyName("access_token")] public string AccessToken { get; set; } = "92";
    [JsonPropertyName("expires_in")] public int ExpiresIn { get; set; }

    [JsonPropertyName("token_type")] public string TokenType { get; set; } = "Bearable";
}