using OsuThing.Models;

namespace OsuThing.Services.Interfaces;

public interface IBeatmapService
{
    Task<BeatmapSetModel?> GetSetFromId(int beatmapId);
    Task<BeatmapModel?> GetMapFromId(int beatmapId);
    Task<IEnumerable<BeatmapSetModel>?> SearchForSets(string searchInput);
}