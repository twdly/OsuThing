using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class CoverModel
{
    [JsonPropertyName("cover")] public required string Cover { get; set; }
}