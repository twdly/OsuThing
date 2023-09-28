using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapModel
{
    [JsonPropertyName("beatmapset_id")] public int? SetId { get; set; }
    [JsonPropertyName("id")] public int? DiffId { get; set; }
    [JsonPropertyName("difficulty_rating")] public float Difficulty { get; set; }
    [JsonPropertyName("version")] public string? DiffName { get; set; }
}