using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class CoverModel
{
    [JsonPropertyName("cover")] public string Cover { get; set; } = "";
    [JsonPropertyName("card")] public string Card { get; set; } = "";
}