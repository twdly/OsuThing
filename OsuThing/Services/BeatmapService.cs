using OsuThing.Models;

namespace OsuThing.Services;

public class BeatmapService(ApiService apiService)
{
    private ApiService ApiService { get; } = apiService;

    public async Task<BeatmapSetModel?> GetSetFromId(int beatmapId)
    {
        var requestParams = $"beatmapsets/{beatmapId}";
        return await ApiService.GetAsync<BeatmapSetModel>(requestParams);
    }
}