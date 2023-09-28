using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapSetModel
{
    [JsonPropertyName("title")] public string? Title { get; set; }
    [JsonPropertyName("covers")] public CoverModel? Covers { get; set; }
    [JsonPropertyName("id")] public int Id { get; set; }
}