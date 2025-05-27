using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class UserStatisticsModel
{
    [JsonPropertyName("pp")] public required float Pp { get; set; }
    [JsonPropertyName("global_rank")] public int Rank { get; set; }
}