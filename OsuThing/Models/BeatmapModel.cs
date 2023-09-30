using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapModel
{
    [JsonPropertyName("beatmapset_id")] public required int SetId { get; set; }
    [JsonPropertyName("id")] public required int DiffId { get; set; }
    [JsonPropertyName("difficulty_rating")] public required float Difficulty { get; set; }
    [JsonPropertyName("version")] public required string DiffName { get; set; }
}