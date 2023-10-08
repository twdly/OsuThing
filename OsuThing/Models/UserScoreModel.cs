using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class UserScoreModel
{
    [JsonPropertyName("position")] public required int Position { get; set; }
    [JsonPropertyName("score")] public required ScoreModel Score { get; set; }
}