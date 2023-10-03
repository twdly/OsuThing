using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class ScoreModel
{

    [JsonPropertyName("accuracy")] public required double Accuracy { get; set; }
    [JsonPropertyName("pp")] public double? Pp { get; set; }
    [JsonPropertyName("max_combo")] public required int MaxCombo { get; set; }
    [JsonPropertyName("beatmap")] public required BeatmapModel Beatmap { get; set; }
    [JsonPropertyName("beatmapset")] public required BeatmapSetModel BeatmapSet { get; set; }
    [JsonPropertyName("mods")] public required List<string> Mods { get; set; }
    [JsonPropertyName("score")] public required int Score { get; set; }

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