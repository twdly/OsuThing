using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class ScoreStatisticsModel
{
    [JsonPropertyName("count_300")] public int ThreeHundreds { get; set; }
    [JsonPropertyName("count_100")] public int Hundreds { get; set; }
    [JsonPropertyName("count_50")] public int? Fifties { get; set; }
    [JsonPropertyName("count_miss")] public int Misses { get; set; }
}