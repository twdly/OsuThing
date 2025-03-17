using System.Text.Json.Serialization;

namespace OsuThing.Models;

public class PerformanceModel
{
    [JsonPropertyName("ranking")] public IEnumerable<UserExtendedModel> Users { get; set; } = [];
}