using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapSetModel
{
    [JsonPropertyName("title")] public string Title { get; set; } = "";
    [JsonPropertyName("covers")] public CoverModel Covers { get; set; } = new();
    [JsonPropertyName("id")] public int Id { get; set; } = 0;
    [JsonPropertyName("beatmaps")] public IEnumerable<BeatmapModel> Difficulties { get; set; } = [];
}