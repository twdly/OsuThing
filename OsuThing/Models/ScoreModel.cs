using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class ScoreModel
{
    [JsonPropertyName("accuracy")] public double Accuracy { get; init; } = -1;
    [JsonPropertyName("pp")] public double? Pp { get; set; } = -1;
    [JsonPropertyName("max_combo")] public int MaxCombo { get; init; } = -1;
    [JsonPropertyName("beatmap")] public BeatmapModel Beatmap { get; set; } = default!;
    [JsonPropertyName("beatmapset")] public BeatmapSetModel? BeatmapSet { get; set; }
    [JsonPropertyName("mods")] public List<string> Mods { get; init; } = [];
    [JsonPropertyName("score")] public int Score { get; set; } = 0;
    
    public double GetRoundedAccuracy()
    {
        return Math.Round(Accuracy * 100, 2);
    }

    public string GetModsAsString()
    {
        if (Mods.Count == 0)
        {
            return "NM";
        }
        const string modString = "+";
        return Mods.Aggregate(modString, (current, mod) => current + mod);
    }
}