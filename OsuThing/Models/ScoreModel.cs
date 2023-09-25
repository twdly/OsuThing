using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class ScoreModel
{
    [JsonPropertyName("id")] public long? Id { get; set; }
    [JsonPropertyName("accuracy")] public double? Accuracy { get; set; }
    [JsonPropertyName("pp")] public double? Pp { get; set; }
    [JsonPropertyName("max_combo")] public int? MaxCombo { get; set; }
    [JsonPropertyName("beatmap")] public BeatmapModel? Beatmap { get; set; }
    [JsonPropertyName("beatmapset")] public BeatmapSetModel? BeatmapSet { get; set; }

    public double GetRoundedAccuracy()
    {
        return Math.Round((double)Accuracy! * 100, 2);
    }
}