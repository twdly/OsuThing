using OsuThing.Models;
using OsuThing.Services.Interfaces;

namespace OsuThing.Services;

public class BeatmapService(IApiService apiService) : IBeatmapService
{
    private IApiService ApiService { get; } = apiService;

    public async Task<BeatmapSetModel?> GetSetFromId(int beatmapId)
    {
        var requestParams = $"beatmapsets/{beatmapId}";
        return await ApiService.GetAsync<BeatmapSetModel>(requestParams);
    }
}