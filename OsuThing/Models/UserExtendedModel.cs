using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class UserExtendedModel
{
    [JsonPropertyName("global_rank")] public int Rank { get; set; }
    [JsonPropertyName("user")] public UserModel User { get; set; }
}