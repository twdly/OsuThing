using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class UserScoreModel
{
    [JsonPropertyName("position")] public int Position { get; set; } = -1;
    [JsonPropertyName("score")] public ScoreModel Score { get; set; } = new();
}