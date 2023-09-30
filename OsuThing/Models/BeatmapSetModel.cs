using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapSetModel
{
    [JsonPropertyName("title")] public required string Title { get; set; }
    [JsonPropertyName("covers")] public required CoverModel Covers { get; set; }
    [JsonPropertyName("id")] public required int Id { get; set; }
}