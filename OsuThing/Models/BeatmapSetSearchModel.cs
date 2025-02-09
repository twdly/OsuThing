using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapSetSearchModel
{
    [JsonPropertyName("beatmapsets")] public required IEnumerable<BeatmapSetModel> BeatmapSets { get; set; }
}