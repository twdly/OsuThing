using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapSetModel
{
    [JsonPropertyName("title")] public string? Title { get; set; }
}