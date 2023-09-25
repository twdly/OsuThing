using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class BeatmapModel
{
    [JsonPropertyName("beatmapset_id")] public int? SetId { get; set; }
    [JsonPropertyName("difficulty_rating")] public float Difficulty { get; set; }
}